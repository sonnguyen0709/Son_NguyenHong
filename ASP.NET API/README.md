# ASP.NET Core REST API & JWT Overview

## 1. REST API

**REST** là viết tắt của **Representational State Transfer**.  
REST API dựa trên HTTP và cung cấp khả năng giao tiếp bằng định dạng JSON nhẹ, chạy trên máy chủ web.

### Thành phần REST

- **Resource**: Tài nguyên có thể nhận dạng duy nhất (ví dụ: dữ liệu DB, hình ảnh,...).
- **Endpoint**: Truy cập tài nguyên qua URL.
- **HTTP Method**: Loại yêu cầu mà client gửi đến server.
- **HTTP Header**: Cặp key-value chứa thông tin bổ sung (dữ liệu gửi, mã hóa, token xác thực,...).
- **Data Format**: JSON là định dạng phổ biến nhất.

---

## 2. JWT Token

**JWT** = **JSON Web Token**  
Chuẩn mở truyền dữ liệu an toàn giữa client và server.

### Cấu trúc JWT
- **Header**: Loại token + thuật toán ký.
- **Payload**: Dữ liệu (claims) cần chia sẻ.
- **Signature**: Ký (Header + Payload) bằng secret key.

**Dạng**: `Header.Payload.Signature`

### Quy trình xử lý
1. **Client yêu cầu token** → gửi thông tin đăng nhập.
2. **Server xác thực** → tạo JWT và trả về client.
3. **Client gửi token** trong header khi gọi API.
4. **Server tài nguyên** xác minh token → cho phép hoặc từ chối truy cập.

---

## 3. API Response

**API Response**: Dữ liệu trả về cho client sau khi xử lý request.

### Kiểu dữ liệu trả về
- `IActionResult`: Linh hoạt nhiều kiểu.
- `ActionResult<T>`: Trả về dữ liệu cụ thể hoặc lỗi.
- Trực tiếp `T`: Luôn trả dữ liệu.

### HTTP Status Codes
#### **1xx – Informational**
- 100 Continue
- 101 Switching Protocols

#### **2xx – Success**
- 200 OK
- 201 Created
- 202 Accepted
- 203 Non-Authoritative Information
- 204 No Content
- 205 Reset Content
- 206 Partial Content
- 207 Multi-Status

#### **3xx – Redirection**
- 300 Multiple Choice
- 301 Moved Permanently
- 302 Found
- 303 See Other
- 304 Not Modified
- 305 Use Proxy

#### **4xx – Client Error**
- 400 Bad Request
- 401 Unauthorized
- 402 Payment Required
- 403 Forbidden
- 404 Not Found

#### **5xx – Server Error**
- 500 Internal Server Error
- 501 Not Implemented
- 502 Bad Gateway
- 503 Service Unavailable
- 504 Gateway Timeout
- 505 HTTP Version Not Supported

---

## 4. HTTP vs HTTPS

| **HTTP** | **HTTPS** |
|----------|----------|
| HyperText Transfer Protocol | HTTP + SSL/TLS |
| Dữ liệu truyền dạng plain text | Dữ liệu được mã hóa |
| Không bảo mật | Bảo mật cao |
| Cổng 80 | Cổng 443 |
| Dễ bị nghe lén | Khó bị nghe lén |
