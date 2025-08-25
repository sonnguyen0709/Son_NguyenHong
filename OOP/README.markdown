# Lập trình hướng đối tượng (OOP) trong C#

Lập trình hướng đối tượng (OOP) là một phương pháp lập trình dựa trên các "đối tượng" – những thực thể chứa dữ liệu (fields/properties) và các hành vi (methods). Bài viết này trình bày các khái niệm cốt lõi của OOP trong C#.

## Tư tưởng chính của OOP
OOP dựa trên bốn nguyên lý chính:
1. **Encapsulation (Tính đóng gói)**
2. **Inheritance (Tính kế thừa)**
3. **Polymorphism (Tính đa hình)**
4. **Abstraction (Tính trừu tượng)**

---

## Encapsulation (Tính đóng gói)
Tính đóng gói giúp ẩn chi tiết cài đặt bên trong class và bảo vệ dữ liệu khỏi truy cập hoặc thay đổi không hợp lệ từ bên ngoài. Dữ liệu chỉ được truy cập thông qua các phương thức (methods) hoặc thuộc tính (properties) được chỉ định.

### Từ khóa sửa đổi truy cập trong C#
- **private**: Chỉ cho phép truy cập trong nội bộ class chứa nó.
- **public**: Cho phép truy cập từ bất kỳ đâu.
- **protected**: Cho phép truy cập trong class chứa nó và các class kế thừa.
- **internal**: Cho phép truy cập trong các class cùng một assembly.
- **protected internal**: Cho phép truy cập trong cùng một assembly và các class kế thừa.

**Lưu ý**: Một class có thể chứa các private class lồng nhau, chỉ hiển thị với class chứa nó.

---

## Inheritance (Tính kế thừa)
Tính kế thừa cho phép tạo một class mới kế thừa thông tin và hành vi từ class cơ sở, giúp tái sử dụng code và mở rộng chức năng mà không cần viết lại.

### Các khái niệm quan trọng
- **virtual**: Khai báo một phương thức ảo ở class cơ sở.
- **override**: Ghi đè phương thức ảo ở class con.
- **base**: Truy cập thông tin từ class cơ sở trong class con, đặc biệt với các phương thức và thuộc tính bị override.
- **abstract class**: Lớp trừu tượng, không thể khởi tạo, phải được kế thừa. Tất cả abstract member phải được lớp con ghi đè.
- **sealed**: Ngăn class hoặc method được kế thừa hoặc ghi đè.

**Lưu ý**: C# không hỗ trợ đa kế thừa (một class chỉ kế thừa từ một class cơ sở duy nhất).

### So sánh Inheritance và Composition
| Đặc điểm            | Inheritance                              | Composition                              |
|---------------------|------------------------------------------|------------------------------------------|
| **Định nghĩa**      | Lớp con kế thừa từ lớp cơ sở để tái sử dụng và mở rộng hành vi | Lớp sử dụng nhiều lớp khác như thành phần nội |
| **Mối quan hệ**     | IS-A (là một)                            | HAS-A (có một)                           |
| **Phạm vi kế thừa** | Chỉ kế thừa từ một lớp cha               | Có thể kết hợp nhiều thành phần          |
| **Liên kết**        | Chặt chẽ: Lớp con phụ thuộc vào lớp cha  | Lỏng lẻo: Lớp chỉ cần biết interface của lớp thành phần |
| **Ghi đè**          | Dễ dàng override phương thức của lớp cha | Cần ủy quyền để điều khiển hành vi       |

---

## Interface (Giao diện)
Interface gần giống abstract class nhưng chỉ chứa khai báo của phương thức, thuộc tính, sự kiện hoặc chỉ số, không chứa code thực thi.

### Đặc điểm của Interface
- Không có field, chỉ có khai báo.
- Không thể khởi tạo trực tiếp.
- Hỗ trợ đa kế thừa interface.
- Một interface có thể kế thừa từ nhiều interface khác.
- Class triển khai interface phải cung cấp code cụ thể cho tất cả phương thức trong interface.
- Mọi thành phần trong interface là **public**.
- Tên interface nên có tiền tố `I` (ví dụ: `IName`, `IValue`).

### Cài đặt tường minh Interface
Dùng khi:
- Hai hoặc nhiều interface có cùng tên thành phần (ví dụ: `Name`, `Start()`).
- Ngăn gọi phương thức interface trực tiếp từ instance (chỉ gọi thông qua interface).

---

## Polymorphism (Tính đa hình)
Tính đa hình cho phép các đối tượng thuộc các class khác nhau được xử lý thông qua cùng một interface hoặc base class.

### Hai kiểu Polymorphism
1. **Compile-time Polymorphism**: Xảy ra ở thời điểm biên dịch, cho phép định nghĩa nhiều phương thức cùng tên nhưng khác tham số.
2. **Run-time Polymorphism**: Xảy ra tại thời điểm chạy, thường sử dụng với inheritance, virtual/override hoặc interface.

---