# C# Advanced Concepts

## 1. Action Delegate
- **Namespace**: `System`
- **Đặc điểm**:
  - Đại diện cho một phương thức **không trả giá trị** (`void`).
  - Có thể nhận **0 đến 16 tham số** đầu vào.
- **Ưu điểm**:
  - Dễ định nghĩa và sử dụng.
  - Giúp code ngắn gọn hơn.
  - Giữ kiểu dữ liệu xuyên suốt.
- **Lưu ý**:
  - Kiểu trả về bắt buộc là `void`.
  - Có thể dùng với **Anonymous Method** hoặc **Lambda Expression**.

---

## 2. Func Delegate
- Tương tự **Action Delegate** nhưng **luôn có giá trị trả về**.
- Cú pháp:  
  `Func<param1Type, param2Type, ..., returnType>`

---

## 3. Anonymous Method
- **Là**: Method không tên, khai báo với từ khóa `delegate` và gán cho biến kiểu delegate.
- **Đặc điểm**:
  - Truy cập được biến bên ngoài phạm vi của nó.
  - Có thể truyền như tham số nếu method chấp nhận delegate.
- **Hạn chế**:
  - Không dùng được `goto`, `break`, `continue`.
  - Không truy cập tham số `ref` hoặc `out` từ method ngoài.
  - Không dùng `unsafe code`.
  - Không thể đứng bên trái toán tử `is`.

---

## 4. Anonymous Type
- **Là**: Class không tên, chỉ chứa thuộc tính `public readonly`.
- **Đặc điểm**:
  - Thuộc tính **readonly** (chỉ đọc).
  - Truy cập bằng dấu `.` như object thường.
  - Có thể tạo mảng chứa **Anonymous Type**.
  - Chỉ tồn tại trong method khai báo, **không return** ra ngoài.
- **Ứng dụng**:  
  Thường dùng trong **LINQ** để chọn dữ liệu một phần.
- **Nội bộ**:
  - Kế thừa từ `System.Object`.
  - Trình biên dịch tự tạo class ẩn với tên ngẫu nhiên.

---

## 5. Delegate
- **Cú pháp**:
  ```csharp
  [access modifier] delegate [return type] DelegateName([params]);
  ```
- **Đặc điểm**:
  - Có thể gán nhiều method bằng `+` hoặc `+=`.
  - Xóa method bằng `-` hoặc `-=`.
  - Gọi delegate như gọi method: `myDelegate()`.
- **Ứng dụng**:
  - Khai báo events.
  - Dùng với Anonymous Method.

---

## 6. Dynamic Type
- Không kiểm tra kiểu tại compile-time, xử lý tại **runtime**.
- Kiểu dữ liệu thay đổi theo giá trị gán.
- Không kiểm tra tên method/properties khi compile nếu kiểu là `dynamic`.

---

## 7. Generic
- **Là**: Kiểu dữ liệu **không cố định** cho trước.
- **Cú pháp**:
  ```csharp
  class MyClass<T> { ... }
  ```
- **Ràng buộc**: Dùng từ khóa `where`.
- Ví dụ:
  ```csharp
  class Repository<T> where T : class { ... }
  ```

---

## 8. Extension Method
- **Là**: Thêm method mới vào class có sẵn mà không cần sửa code gốc.
- **Cú pháp**:
  ```csharp
  public static class MyExtensions
  {
      public static void Print(this string str)
      {
          Console.WriteLine(str);
      }
  }
  ```
- **Lưu ý**:  
  Tham số đầu tiên phải có từ khóa `this`.

---

## 9. Event
- **Là**: Cơ chế phát tín hiệu khi có sự kiện.
- **Cú pháp**:
  ```csharp
  public event EventHandler MyEvent;
  ```
- **Đặc điểm**:
  - Gọi event bằng `?.Invoke(...)`.
  - Đặt tên method raise event theo quy tắc: `On[TênSựKiện]`.
  - Truyền dữ liệu với `EventHandler<TEventArgs>`.

---

## 10. HttpClient
- **BaseAddress**: URL gốc của API.
- **Các phương thức**:
  - **GET**: Lấy dữ liệu.
  - **POST**: Gửi dữ liệu mới.
  - **PUT**: Cập nhật toàn bộ.
  - **PATCH**: Cập nhật một phần.
  - **DELETE**: Xóa dữ liệu.
  - **HEAD**: Lấy header.
  - **OPTIONS**: Kiểm tra phương thức HTTP hỗ trợ.
- **Ví dụ GET**:
  ```csharp
  var client = new HttpClient { BaseAddress = new Uri("https://api.example.com/") };
  var response = await client.GetAsync("todos/5");
  response.EnsureSuccessStatusCode();
  var json = await response.Content.ReadAsStringAsync();
  Console.WriteLine(json);
  ```

---

## 11. Generic Constraints
- **Dùng**: Hạn chế kiểu dữ liệu khi khai báo generic.
- **Các loại**:
  - `where T : class` → Kiểu tham chiếu.
  - `where T : struct` → Kiểu giá trị.
  - `where T : new()` → Có constructor không tham số.
  - `where T : SomeClass` → Phải kế thừa `SomeClass`.
