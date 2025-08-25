
-------------------------
---------- C# Convention

# A. Quy tắc và quy ước đặt tên trong C#
## 1. Quy tắc đặt tên
+) Một định danh (Identifier) là tên bạn gán cho một kiểu (class, interface, struct, delegate hoặc enum), thành viên, biến hoặc namespace.

+) Các định danh hợp lệ phải tuân theo các quy tắc sau. Trình biên dịch C# sẽ báo lỗi nếu bất kỳ định danh nào không tuân thủ các quy tắc này:

* Định danh phải bắt đầu bằng một chữ cái hoặc dấu gạch dưới (_)
* Định danh có thể chứa:

  * Các ký tự chữ cái Unicode
  * Ký tự chữ số thập phân
  * Ký tự kết nối Unicode
  * Ký tự tổ hợp Unicode
  * Ký tự định dạng Unicode

* Bạn có thể khai báo định danh trùng với từ khóa trong C# bằng cách dùng tiền tố @. Ví dụ: @if sẽ khai báo một định danh có tên if.
* @ không phải là một phần của tên định danh, và chủ yếu được dùng để tương thích với các định danh trong các ngôn ngữ khác.
* Ngôn ngữ C# chỉ cho phép các loại ký tự Unicode thuộc các danh mục sau:
  * Chữ cái (Lu, Ll, Lt, Lm, Nl)
  * Chữ số (Nd)
  * Ký tự kết nối (Pc)
  * Ký tự tổ hợp (Mn, Mc)
  * Ký tự định dạng (Cf)
  * Bất kỳ ký tự nào không thuộc các loại trên sẽ bị thay thế bằng dấu gạch dưới (_)

## 2. Quy ước đặt tên

* Tên cần phải thể hiện được ý nghĩa một cách tường minh.
* Tránh những cách đặt tên mơ hồ, khó hiểu
* Sử dụng PascalCase (viết hoa mỗi chữ cái đầu) cho : class, record, struct, namespace, thành viên của kiểu, chẳng hạn như trường, thuộc tính, sự kiện, phương thức và hàm cục bộ. Riêng interface nên có tiền tố I.
* Sử dụng camelCase (chữ đầu viết thường, sau đó viết hoa mỗi chữ cái đầu) cho : biến private hoặc internal, biến cục bộ, tham số phương thức
* Đặt tên cho tham số Generic
  * Dùng tên có mô tả cho type parameter, trừ khi một chữ cái là đủ rõ nghĩa
  * Nếu chỉ có một tham số kiểu => có thể dùng T.
  * Nên thêm tiền tố T vào tên type parameter mô tả.

# B.Quy ước mã hóa trong C#

## Language Guidelines

* Sử dụng các tính năng và phiên bản C# hiện đại.
* Tránh dùng cú pháp lỗi thời.
* Dùng LINQ để xử lý bộ sưu tập giúp mã dễ đọc hơn.
* Dùng loại exception cụ thể để thông báo lỗi rõ ràng.
* Chỉ dùng ```var``` nếu người đọc có thể đoán được kiểu từ biểu thức
* Luôn luôn sử dụng kiểu dữ liệu C# (như int, double, string, ulong) thay vì kiểu dữ liệu .NET (như Int32, Double, String, UInt64)

## Chuỗi (String)

* Dùng string interpolation
* Nếu lặp nhiều lần với chuỗi dài => dùng StringBuilder
* Ưu tiên dùng raw string literals thay vì escape sequence

## Constructor và khởi tạo

* Dùng PascalCase cho tham số của record
* Dùng camelCase cho class/struct constructor
* Dùng required properties thay vì constructor để buộc khởi tạo

## Array

* Dùng collection expressions để khởi tạo tất cả các loại bộ sưu tập

## Delegates

* Dùng `Func<>` và `Action<>` thay vì định nghĩa delegate mới
* Gọi phương thức bằng cách sử dụng chữ ký được xác định bởi `Func<>`, `Action<>`

## `try-catch` và `using`

* Sử dụng `try-catch` để xử lý hầu hết trường hợp ngoại lệ
* Nếu có câu lệnh `try-finally` mà chỉ cần gọi `Dispose` thì dùng `using` thay thế

## Toán tử `&&` và `||`

* Dùng `&&` thay vì `&`, `||` thay vì `|` để tránh lỗi runtime

## Toán tử `new`

* Dùng cú pháp gọn khi kiểu biến khớp kiểu đối tượng
* Ưu tiên dùng object initializer

## Xử lý event

* Sử dụng biểu thức lambda để xác định trình xử lý sự kiện mà bạn không cần phải xóa sau này

## Biến kiểu ngầm định (var)

* Dùng `var` khi kiểu rõ ràng
* Không dùng `var` khi kiểu không rõ ràng
* Sử dụng kiểu ngầm định cho biến trong vòng lặp `for`, không dùng cho vòng lặp `foreach`

## namespace

* Hầu hết các tệp mã đều khai báo một không gian tên duy nhất. Do đó, các ví dụ của chúng ta nên sử dụng khai báo không gian tên có phạm vi tệp
* Nên đặt `using` ngoài namespace để tránh lỗi phân giải tên

## Phong cách viết mã

* Dùng 4 dấu cách để thụt lề, không dùng tab
* Giới hạn mỗi dòng tối đa 65 ký tự
* Cải thiện tính rõ ràng và trải nghiệm của người dùng bằng cách chia các câu lệnh dài thành nhiều dòng
* Dùng Allman style cho dấu `{ }` (mỗi dấu trên dòng riêng)
* Xuống dòng trước toán tử nhị phân nếu cần

## Comment code

* Dùng `//` cho chú thích ngắn
* Với class/method/field dùng chú thích XML (`///`)
* Đặt chú thích ở một dòng riêng, không phải ở cuối dòng mã
* Chèn một khoảng trắng giữa dấu phân cách chú thích (`//`) và văn bản chú thích

## Quy ước trình bày 

* Mỗi dòng chỉ có một lệnh hoặc khai báo
* Nếu các dòng tiếp theo không được thụt lề tự động, hãy thụt lề chúng một tab (4 khoảng trắng)
* Cách dòng giữa các method/property
* Dùng dấu ngoặc và dấu ngoặc đơn hợp lý để biểu thị cấu trúc











