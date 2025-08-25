# LINQ Overview

## 1. LINQ là gì?
**LINQ** (Language Integrated Query) là cú pháp cho phép truy vấn dữ liệu một cách ngắn gọn, dễ đọc và mạnh mẽ giống như SQL, nhưng hoạt động trên các collection như:
- `List`
- `Array`
- `IEnumerable`
- `IQueryable`
- ...

---

## 2. Standard Operations

### 2.1 Restriction
- **Where**: Lọc dữ liệu.

### 2.2 Projection
- **Select**: Chọn và chuyển đổi từng phần tử.
- **SelectMany**: Làm phẳng dữ liệu lồng nhau.

### 2.3 Partitioning
- **Take**: Lấy `n` phần tử đầu tiên.
- **Skip**: Bỏ qua `n` phần tử đầu tiên.
- **TakeWhile(condition)**: Lấy phần tử cho đến khi điều kiện sai.
- **SkipWhile(condition)**: Bỏ qua phần tử cho đến khi điều kiện sai.

### 2.4 Ordering
- **OrderBy**, **ThenBy**: Sắp xếp tăng dần.
- **OrderByDescending**, **ThenByDescending**: Sắp xếp giảm dần.
- **Reverse**: Đảo ngược thứ tự.

### 2.5 Grouping
- **GroupBy**: Gom nhóm theo 1 hoặc nhiều khóa.

### 2.6 Set Operations
- **Distinct**: Loại bỏ phần tử trùng.
- **Union**: Hợp 2 tập hợp, loại bỏ trùng.
- **Intersect**: Giao 2 tập hợp.
- **Except**: Hiệu (list1 - list2).  
> Nếu dùng trên object cần override `Equals()` và `GetHashCode()`.

### 2.7 Conversion
- **ToArray**, **ToList**, **ToDictionary**: Chuyển đổi collection.
- **OfType<T>**: Lọc và ép kiểu.

### 2.8 Element Operators
- **First** / **FirstOrDefault**: Lấy phần tử đầu tiên.
- **Last** / **LastOrDefault**: Lấy phần tử cuối.
- **ElementAt(index)** / **ElementAtOrDefault(index)**: Lấy phần tử tại vị trí.
- **Single** / **SingleOrDefault**: Trả về phần tử duy nhất.

### 2.9 Generation
- **Enumerable.Range(start, count)**: Tạo chuỗi số nguyên liên tiếp.
- **Enumerable.Repeat(value, count)**: Tạo chuỗi lặp lại cùng giá trị.

### 2.10 Quantifier
- **Any**: Có ít nhất 1 phần tử thỏa điều kiện.
- **All**: Tất cả phần tử thỏa điều kiện.
- **Contains**: Tập hợp chứa giá trị.

### 2.11 Aggregate
- **Count**, **Sum**, **Max**, **Min**: Thống kê.
- **Aggregate**: Tính toán dồn tích.

### 2.12 Join
- **Join**: Kết hợp 2 tập hợp khi khóa khớp.
- **GroupJoin**: Giống Join nhưng trả về tập con ở bên phải.
- **LeftJoin**: Giữ toàn bộ dữ liệu bên trái.

---

## 3. Some other method

### 3.1 Zip
- **Zip** ghép hai tập hợp theo vị trí phần tử
- Nếu 2 tập có độ dài khác nhau → lấy theo tập ngắn hơn
- Có Overload cho phép tạo ra object mới 

### 3.2 Concat
- **Concat** cho phép nối hai tập hợp không loại bỏ trùng 

### 3.3 SequenceEqual
- **SequenceEqual** so sánh hai tập hợp có **giống nhau 100%** không (giả trị + thứ tự)

### 3.4 Chunk
- **Chunk** Chia 1 tập hợp thành nhiều mảng con có kích thước cố định 
---

## 4. IEnumerable vs IQueryable

### IEnumerable
- Interface cho các collection có thể lặp.
- Định nghĩa trong `System.Collections.Generic`.
- LINQ dùng cho dữ liệu **trong bộ nhớ** (List, Array,...).

### IQueryable
- Định nghĩa trong `System.Linq`.
- Dùng để truy vấn dữ liệu **từ nguồn ngoài** (DB, LINQ to SQL,...).
- Cho phép dịch LINQ sang SQL, thực thi tại database.
