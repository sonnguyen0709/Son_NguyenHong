# Entity Framework Core - Code First Guide

## 📖 Mục lục
1. [Code First](#1-code-first)
2. [Migration](#2-migration)
3. [DbContext](#3-dbcontext)
4. [DbSet](#4-dbset)
5. [Entity Configuration](#5-entity-configuration)
   - [Data Annotation](#-data-annotation)
   - [Fluent API](#-fluent-api)
6. [Loading Data (Lazy vs Eager)](#6-loading-data-lazy-vs-eager)
   - [Lazy Loading](#-lazy-loading)
   - [Eager Loading](#-eager-loading)
7. [Tracking](#7-tracking)
   - [AsNoTracking()](#-asnotracking)
   - [Global No Tracking](#-global-no-tracking)
8. [Split Query](#8-split-query)
   - [AsSplitQuery()](#-assplitquery)
   - [Global Split Query](#-global-split-query)
9. [Optimize Performance](#9-optimize-performance)
   - [Giảm tracking](#giảm-tracking-nếu-không-cần-thiết)
   - [Projection (Select)](#dùng-projection-select-thay-vì-lấy-cả-entity)
   - [Eager Loading](#eager-loading-hợp-lý-includetheninclude)
   - [Batch Operations](#batch-operations-giảm-số-round-trip-đến-db)
   - [Compiled Queries](#complied-queries)
   - [Skip/Take (Paging)](#a-skiptake-paging-khi-dữ-liệu-nhiều)
   - [Query cần thiết](#b-chỉ-query-những-gì-cần-thiết)
   - [Tránh ToList sớm](#c-tránh-tolist-quá-sớm)
   - [Index trong Database](#index-trong-database)
   - [BulkInsert/BulkUpdate](#dùng-bulkinsertbulkupdate-khi-thêm-hoặc-cập-nhập-lượng-lớn-dữ-liệu)

---

## 1. Code First
Code First là phương pháp trong **Entity Framework Core** cho phép bạn viết class C# (model) trước, 
sau đó EF Core sẽ tự sinh ra **database** và **bảng** từ những class này.

👉 Khi bạn muốn **thiết kế CSDL ngay trong code**, không cần tạo thủ công trên SQL Server trước.

---

## 2. Migration
Migration là cơ chế giúp theo dõi và cập nhật thay đổi của model (class C#) vào database mà **không cần xóa DB tạo lại**.

### 🎯 Chức năng
- Chuyển từ code sang database schema
- Quản lý lịch sử thay đổi CSDL

### ⚡ Các command Migration
```powershell
Add-Migration MigrationName     # Tạo migration mới
Update-Database                 # Update DB theo migration mới nhất
Update-Database MigrationName   # Update đến một migration cụ thể
Remove-Migration                # Xóa migration gần nhất
Update-Database 0               # Đặt DB về trạng thái ban đầu
Get-Migration                   # Xem danh sách migration
Drop-Database                   # Xóa toàn bộ database
```

---

## 3. DbContext
`DbContext` là lớp trung gian giữa code C# và database.

### 🎯 Chức năng
- Kết nối DB  
- Theo dõi các thay đổi của entity  
- Thực hiện **CRUD** (Create, Read, Update, Delete)  

---

## 4. DbSet
- Đại diện cho **một bảng trong CSDL**  
- Mỗi `DbSet<TEntity>` là tập hợp các object kiểu `TEntity` mà bạn có thể query hoặc lưu vào DB  

---

## 5. Entity Configuration
Là cách cấu hình entity trong EF Core.

### 🔹 Data Annotation
- Cấu hình ngay trên class/properties bằng attribute  
- Phù hợp khi quy tắc đơn giản, ít thay đổi  
- Ngoài tạo schema DB, còn phục vụ **validate** ở tầng API/MVC (ModelState)  

### 🔹 Fluent API
- Cấu hình qua **ModelBuilder** trong `DbContext`  
- Rất linh hoạt, hỗ trợ gần như tất cả tính năng mapping nâng cao:
  - Composite key, Alternate key
  - Conversion, Owned types
  - Query filter, Seed data
  - Delete behavior
  - Inheritance mapping  
---

## 6. Loading Data (Lazy vs Eager)

### 🔹 Lazy Loading
- Chỉ tải dữ liệu **chính**, dữ liệu liên quan chỉ load khi truy cập  

✅ Ưu điểm  
- Giảm tải dữ liệu ban đầu  
- Tiết kiệm băng thông  

❌ Nhược điểm  
- Có thể gây **N+1 query problem**  
- Chậm nếu cần nhiều dữ liệu liên quan  

---

### 🔹 Eager Loading
- Tải luôn dữ liệu liên quan ngay từ đầu (JOIN hoặc multiple queries)  
- Dùng `Include` và `ThenInclude`  

✅ Ưu điểm  
- Tránh **N+1 query problem**  
- Tăng tốc khi cần nhiều dữ liệu liên quan ngay  

❌ Nhược điểm  
- Có thể tải nhiều dữ liệu không cần thiết  
- Query nặng nếu JOIN nhiều bảng lớn  

---

## 7. Tracking

### 🔹 AsNoTracking()
- `AsNoTraking()` là một **query modifier** dùng để **tắt tracking** của EF Core khi query dữ liệu 
- Mặc định, EF Core sẽ **tracking** entity (theo dõi thay đổi trong Change Tracker)  
- Giúp bạn sửa entity rồi `SaveChanges()` để EF tự sinh `UPDATE/DELETE`  

👉 Tuy nhiên, tracking **tốn RAM + CPU** → không cần thiết khi chỉ đọc dữ liệu  

✅ Nên dùng `AsNoTracking()` khi:  
- Query **read-only**  
- API response trả về DTO/ViewModel  
- Query số lượng lớn dữ liệu  

❌ Không nên dùng khi:  
- Cần update entity rồi `SaveChanges()`  
- Muốn EF hỗ trợ lazy-loading navigation property  

### 🔹 Global No Tracking
- Nếu muốn EF Core **mặc định mọi query đều không tracking** có thể set trong `OnConfiguring` hoặc `Program.cs`:
```csharp
options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
```
👉 Khi đó, nếu muốn bật lại tracking:  
```csharp
query.AsTracking();
```

---

## 8. Split Query

### 🔹 AsSplitQuery()
Khi dùng `Include` nhiều bảng, EF Core sẽ sinh ra một câu **SQL JOIN khổng lồ**:
- Dễ bị **cartesian explosion** (nhân bản dữ liệu → rất nhiều dòng trùng)
- Có thể ảnh hưởng **hiệu năng** và gây lỗi **"Query contains Cartesian product..."**

👉 Giải pháp: `AsSplitQuery()` → **tách query lớn thành nhiều query nhỏ** rồi merge ở RAM.  

```csharp
var owners = _context.Owners
    .Include(o => o.Pokemons)
    .ThenInclude(p => p.Reviews)
    .AsSplitQuery()   // ⚡ Tách ra nhiều query
    .ToList();
```

📌 Khi đó:
- 1 query cho `Owner`  
- 1 query cho `Pokemon`  
- 1 query cho `Reviews`  

### ✅ Nên dùng khi
- Query nhiều `Include` gây nhân bản dữ liệu  
- Dữ liệu lớn, JOIN nhiều bảng  

### ❌ Không cần khi
- Query đơn giản (1-2 bảng)  
- Muốn hạn chế round-trip DB  

### 🔹 Global Split Query
Nếu muốn luôn dùng **SplitQuery**:
```csharp
optionsBuilder.UseSqlServer(connectionString,
    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
```
👉 Nếu muốn ép SingleQuery:
```csharp
query.AsSingleQuery();
```

---

## 9. Optimize performance
- Tối ưu hiệu năng trong EF Core thường liên quan đến cách **query dữ liệu, tracking entity, cấu trúc DB, cách sử dụng DB Context**, sau đây là một vài kỹ thuật

### Giảm tracking nếu không cần thiết
- Như đã đề cập trong phần 7 [Tracking](#7-tracking)

### Dùng Projection (Select) thay vì lấy cả entity
- Không nên load toàn bộ dữ liệu nếu chỉ cần vài field

```csharp
// Tốn bộ nhớ (lấy toàn bộ entity)
var pokemons = _context.Pokemons.ToList();

// Tối ưu (chỉ lấy dữ liệu cần thiết)
var pokemons = _context.Pokemons
    .Select(p => new { p.Id, p.Name })
    .ToList();
```

### Eager Loading hợp lý (Include/ThenInclude)
- Như đã đề cập ở phần 6 [Loading Data](#6-loading-data-lazy-vs-eager)  

```csharp
// Thay vì query nhiều lần -> N+1 problem
var owners = _context.Owners.ToList();
foreach (var owner in owners)
{
    var pokemons = _context.Pokemons
        .Where(p => p.OwnerId == owner.Id)
        .ToList();
}

// Tối ưu (Eager loading)
var owners = _context.Owners
    .Include(o => o.Pokemons)
    .ToList();
```

- Tuy nhiên **không nên Include quá nhiều navigation** vì sẽ kéo quá nhiều dữ liệu, nếu chỉ cần field con hãy dùng projection

### Batch Operations (giảm số round-trip đến DB)
- EF Core gọi **SaveChange()** nhiều lần sẽ tốn query, thay vào đó hãy gộp lại

```csharp
// Chậm (nhiều lần query DB)
foreach (var pokemon in pokemons)
{
    _context.Pokemons.Add(pokemon);
    _context.SaveChanges();
}

// Nhanh (1 round-trip)
_context.Pokemons.AddRange(pokemons);
_context.SaveChanges();
```

### Complied Queries
- Trong EF Core mỗi khi dùng LINQ query, mỗi lần thực thi EF Core phải:
  - Phân tích cú pháp LINQ thành Expression Tree
  - Dịch Expression Tree thành SQL
  - Tối ưu kế hoạch thực thi (query plan)
👉 Nếu chạy **cùng 1 query nhiều lần** (chỉ khác tham số), thì chi phí **biên dịch query** bị lặp lại, ảnh hưởng đến hiệu năng

- Để khắc phục điều này, có thể dùng **Complied Query**
  - EF Core cho phép **complie trước query** và tái sử dụng → bỏ qua bước phân tích, phiên dịch lại
  - Mỗi lần gọi chỉ cần gắn lại tham sô

```csharp
static readonly Func<MyDbContext, string, Pokemon?> _compiledQuery =
    EF.CompileQuery((MyDbContext ctx, string name) =>
        ctx.Pokemons.FirstOrDefault(p => p.Name == name));

// Sử dụng
var pikachu = _compiledQuery(_context, "Pikachu");
```
### Giảm số lượng dữ liệu trả về 

#### a. Skip/Take (paging) khi dữ liệu nhiều
- Khi bảng có quá nhiều dữ liệu, nếu `ToList()` toàn bộ thì
  - EF Core sẽ lấy hết dữ liệu về memory → cực kỳ nặng
  - Rất dễ gây **TimeOut, OutOfMemory** hoặc làm API chậm
👉 Giải pháp: **chia trang (paging)** bằng `Skip` và `Take`

```csharp
var pokemons = context.Pokemons
    .OrderBy(p => p.Id)  // luôn cần có OrderBy khi phân trang
    .Skip(0)             // bỏ qua bản ghi đầu tiên (trang 1 thì = 0)
    .Take(20)            // chỉ lấy 20 bản ghi
    .ToList();
```

#### b. Chỉ query những gì cần thiết
- Mặc định EF Core sẽ lấy **toàn bộ cột** của entity
- Nếu chỉ cần vài field thì không nên `ToList()` cả object
- Nên dùng `Select()`, `Where()` để lọc các dữ liệu cần thiết

#### c. Tránh `ToList()` quá sớm
- `ToList()` sẽ **materialize query** → chạy SQL ngay lập tức → load dữ liệu vào RAM
- Hãy dùng `Where()`, `Select()`,... trước rồi hãy materialize

### Index trong Database

#### Index
- **Index (chỉ mục)** trong SQL giống như **mục lục sách**, DBMS có thể tra mục lục để đến thẳng vị trí dữ liệu
- Khi sử dụng `Where`, `Join`, `OrderBy`, `GroupBy` trên cột có Index sẽ truy vấn nhanh hơn nhiều

#### Ví dụ về Index

```csharp
var pokemons = _context.Pokemons
    .Where(p => p.Type == "Fire")
    .ToList();
```

Nếu không có Index
- Query `WHERE Type = "Fire"`
- SQL đọc toàn bộ các rows rồi lọc ra vài dòng → chậm
Nếu có Index
- Query nhảy thẳng đến vị trí trong Index của `Type = "Fire"`
- Chỉ cần đọc vài dòng cần thiết → tốc độ nhanh

#### Khai báo Index 
Có thể tạo Index trong `DB Context`, dùng `modelBuilder`

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Pokemon>()
        .HasIndex(p => p.Type);
}
```

Sau đó chỉ cần `Add-Migration` và `Update-Database`, EF Core sẽ tạo Index trong DB

#### Khi nào nên dùng Index
- Các cột thường xuyên:
  - `Where()` (lọc dữ liệu)
  - `Join()` (kết nối bảng)
  - `OrderBy()`, `GroupBy()`
- Tuy nhiên không nên tạo quá nhiều Index không cần thiết → gây tốn bộ nhớ và chậm khi **INSERT/UPDATE/DELETE** (vì phải update Index)

### Dùng BulkInsert/BulkUpdate khi thêm hoặc cập nhập lượng lớn dữ liệu

#### Vấn đề khi dùng Insert/Update thông thường
- EF Core mặc định **theo dõi từng entity (ChangeTracker)**
- Với mỗi entity được thêm/sửa, EF sẽ phải:
  - Gọi `DetectChanges()` (rất tốn CPU nếu lượng entity lớn)
  - Sinh câu lệnh `INSERT` hoặc `UPDATE` riêng cho từng entity
- Nếu lượng entity lớn, tốc độ làm việc rất chậm

#### BulkInsert/BulkUpdate
- **Bỏ qua ChangeTracker** → không tốn thời gian tracking từng entity
- Chèn/cập nhật nhiều dữ liệu cùng lúc
- **Giảm tải SQL Server** vì số câu lệnh ít hơn nhiều

```csharp
t = new AppDbContext())
{
    var pokemons = new List<Pokemon>();

    for (int i = 0; i < 100000; i++)
    {
        pokemons.Add(new Pokemon
        {
            PokemonSpeciesId = 1,
            Nickname = "Pikachu_" + i,
            BirthDate = DateTime.Now
        });
    }

    // ✅ BulkInsert
    context.BulkInsert(pokemons);

    // ✅ BulkUpdate
    foreach (var p in pokemons)
    {
        p.Nickname = p.Nickname + "_Updated";
    }
    context.BulkUpdate(pokemons);
}
```

### Logging & Profiling
- Dùng `ToQueryString()` để xem SQL EF Core sinh ra, tránh query nặng

```csharp
var query = _context.Pokemons
    .Where(p => p.Type == "Fire");

Console.Writeline(query.ToQueryString());
```

👉 `ToQueryString()` sẽ dịch LINQ thành SQL và in ra

```sql
SELECT [p].[Id], [p].[Name], [p].[Type]
FROM [Pokemons] AS [p]
WHERE [p].[Type] = N'Fire'
```

Ý nghĩa:
- Giúp bạn biết SQL mà EF Core sinh ra → phát hiện query có join quá nhiều bảng, SELECT* dư thừa, hoặc điều kiện lọc kém hiệu quả
- Nếu query quá nặng hoặc dư thừa, có thể tối ưu lại LINQ

## 10. Relationship

### One-to-One
- Mỗi bản ghi A có **tối đa 1** bản ghi B liên quan, và ngược lại
- Mô hình (shared primary key - khuyến nghị)

```csharp
public class User {
    public int Id { get; set; }
    public UserProfile Profile { get; set; }   // 1–1
}
public class UserProfile {
    // dùng chung PK = FK về User
    public int UserId { get; set; }
    public string Address { get; set; }
    public User User { get; set; }
}
```

- Fluent API

```csharp
protected override void OnModelCreating(ModelBuilder mb)
{
    mb.Entity<UserProfile>().HasKey(p => p.UserId); // shared PK

    mb.Entity<User>()
      .HasOne(u => u.Profile)
      .WithOne(p => p.User)
      .HasForeignKey<UserProfile>(p => p.UserId)
      .OnDelete(DeleteBehavior.Cascade); // hoặc Restrict
}
```

### One-to-Many
- Một bản ghi A có **nhiều** bản ghi B; B **thuộc về** đúng một A
- Mô hình 

```csharp
public class Category {
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; } = new();
}
public class Product {
    public int Id { get; set; }
    public string Name { get; set; }

    // FK “required” → quan hệ bắt buộc
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
```

- Fluent API

```csharp
protected override void OnModelCreating(ModelBuilder mb)
{
    mb.Entity<Product>()
      .HasOne(p => p.Category)            // child -> parent
      .WithMany(c => c.Products)          // parent -> children
      .HasForeignKey(p => p.CategoryId)
      .OnDelete(DeleteBehavior.Restrict); // cân nhắc Cascade/SetNull/ClientSetNull
}
```

### Many-to-Many
- Mỗi A có nhiều B, mỗi B có nhiều A
- Mô hình

```csharp
public class StudentCourse {               // bảng nối có payload
    public int StudentId { get; set; }
    public int CourseId  { get; set; }

    public Student Student { get; set; }
    public Course Course { get; set; }
}
public class Student {
    public int Id { get; set; }
    public ICollection<Grade> Grades { get; set; } = new();
}
public class Course {
    public int Id { get; set; }
    public ICollection<Grade> Grades { get; set; } = new();
}
```

- Fluent API

```csharp
protected override void OnModelCreating(ModelBuilder mb)
{
    mb.Entity<StudentCourse>().HasKey(g => new { g.StudentId, g.CourseId }); // composite PK

    mb.Entity<StudentCourse>()
      .HasOne(g => g.Student)
      .WithMany(s => s.Grades)
      .HasForeignKey(g => g.StudentId);

    mb.Entity<StudentCourse>()
      .HasOne(g => g.Course)
      .WithMany(c => c.Grades)
      .HasForeignKey(g => g.CourseId);

    // Nếu muốn “mỗi SV chỉ có 1 điểm cho 1 môn”, PK ghép đã đảm bảo
    // hoặc thêm Unique Index nếu GradeId là PK riêng.
}
```

### DeleteBehavior
- Lựa chọn đúng cho mỗi quan hệ
- `Cascade`: xóa parent xóa luôn con (cẩn trọng với chuỗi cascade dài)
- `Restrict/NoAction`: chặn xóa nếu còn con (an toàn cho dữ liệu)
- `SetNull`: khi xóa parent, FK ở child set `NULL` (chỉ dùng nếu FK nullable)
- `ClientSetNull`: client set null, DB không cascade
- Default của EF Core là `ClientSetNull`

---

## 11. Database First
- Database First: Khi đã có sẵn Database (tạo bằng SQL, script SQL,...) → dùng EF Core để **reverse engineer** (tạo ra model C# từ DB)
- Ngược lại với Code First (tạo model → sinh database)

### Cách sử dụng Database First
- Để Reverse Engineer (Scaffold) chạy lệnh 

```power cell
Scaffold-DbContext "Connection string" Microsoft.EntityFrameworkCore.SqlServer -OuputDir Models -Context DbContextName -f
```
Trong đó:
  🔹 Connection string: Connection string của DB của đã có
  🔹 DbContextName: Tên DbContext

Nếu dùng .Net CLI:
```bash
dotnet ef dbcontext scaffold "Connection string" Microsoft.EntityFrameworkCore.SqlServer -o Models -c DbContextName --force
```

- Khi đó EF Core sẽ tạo ra
  - DbContextName.cs → chứa DbSet cho từng bảng 
  - Entity Classer → ánh xạ bảng 
  - Folder Models sẽ chứa các entity classer
- Nếu muốn tùy chỉnh thêm, vẫn có thể dùng FLuent API trong `OnModelCreating`

### Ưu nhược điểm của Database First

#### a. Ưu điểm
- Thích hợp khi đã DB lớn sẵn
- Không phải viết model từ đầu
- Có thể đổng bộ lại khi DB thay đổi (`Scaffold` lại) 
#### b. Nhược điểm 
- Ít linh hoạt khi muốn kiểm soát DB bằng code
- Mỗi lần đổi DB → phải `Scaffold` lại

---

## 12. **Dependency Injection (DI)** 
- Là "vòng đời" của instance khi container tạo object cho bạn, ASP.NET Core có 3 kiểu: 
  - Transient
  - Scoped
  - Singleton

### Transient
- **Tạo mới mỗi lần**: mỗi contructor inject, mỗi lần resolve đều tạo ra instance khác nhau
- Ưu: Không giữ state, giảm rủi ro rò rỉ state giữa nơi dùng
- Nhược: Tạo nhiều instance → chi phí GC/khởi tạo tăng; nếu phụ thuộc tài nguyên đắt (kết nối DB, socket) là **không phù hợp**
- **Khi nào dùng**: Service thuần tính toán, không IO nặng, không giữ cache/state

```csharp
builder.Services.AddTransient<IMailer, SmtpMailer>();
```
### Scoped
- **1 instance/ 1 HTTP request** (và dùng chung giữa mọi service trong cùng request)
- Ưu: Phù hợp cho "đơn vị công việc" (unit-of-work): transaction, change tracking nhất quán
- Nhược: Không dùng trực tiếp trong background singletion, phải tạo scope

```csharp
builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlServer(connStr)); // mặc định Scoped
builder.Service.AddScoped<IUserService, UserService>();
```

### Singleton
- **Một instance cho toàn ứng dụng**: an toàn khi dùng đa luồng (thread-safe) hoặc bất biến (inmmutable)
- **Không thread-safe** → không nên dùng Singleton
- **Tuyệt đối tránh**: `DbContext` singleton (DbContext không **thread-safe** và có change tracker)

```csharp
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();
```

### Quy tắc an toàn
- **Không inject Scoped vào Singleton**: gây lỗi `Cannot comsume scoped service from singleton`
- Nếu cần hãy inject `IServiceScopeFactory` và tạo scope khi dùng
- `Đừng giữ reference Scoped qua request khác`: chỉ dùng khi scope sống
- **Singleton phải thread-safe**: nếu có state thay đổi, dùng lock/Concurrent hoặc thiết kế immutable
- **Dispose đúng**: container sẽ tự dispose theo lifetime; đừng tự dispose những thứ do DI tạo

### Quick checklist chọn lifetime
- **Có dùng DbContext/transaction/state theo request? → Scoped**
- **Chỉ là tính toán thuần, không state → Transient**
- **Cấu hình/cached lookup/thread-safe → Singleton**
