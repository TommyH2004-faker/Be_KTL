# Be_KTL - Backend website khóa học

Project này là backend cho một website bán và học khóa học theo mô hình Clean Architecture trên .NET 8.

## Mục tiêu

- Quản lý người dùng, phân quyền, hồ sơ học viên và giảng viên.
- Quản lý khóa học, danh mục, chương học, bài học, video, tài liệu.
- Quản lý đăng ký học, tiến độ học, chứng chỉ, đánh giá.
- Quản lý giỏ hàng, đơn hàng, thanh toán, coupon và wishlist.
- Quản lý livestream, thông báo và lịch sử session đăng nhập.
- Chuẩn hóa API, domain, application và infrastructure để có thể mở rộng lâu dài.

## Trạng thái hiện tại

- Solution đã có 4 project chính: API, Application, Domain, Infrastructure.
- Domain entity đã được chuẩn hóa theo hướng course marketplace/LMS.
- Các phần Application và Infrastructure hiện còn trống hoặc rất mỏng, cần triển khai tiếp.

## Kiến trúc đề xuất

- `Be_Ktl.Domain`: entity, enum, value object, business rule cốt lõi.
- `Be_Ktl.Application`: use case, DTO, interface, validation, mapping.
- `Be_Ktl.Infrastructure`: EF Core, Identity, repository, external service, payment, storage.
- `Be_Ktl.API`: controller, middleware, auth, swagger, exception handling.

## Danh mục domain cần có

### Người dùng và phân quyền

- User
- Role
- Instructor profile
- User session
- Notification

### Học tập

- Category
- Course
- Chapter
- Lesson
- Video
- Lesson resource
- Course objective
- Course requirement
- Enrollment
- Lesson progress
- Certificate
- Review

### Thương mại

- Cart
- Cart item
- Order
- Order item
- Payment
- Coupon
- Wishlist

### Livestream

- Livestream

## Chuẩn hóa domain đã áp dụng

- Dùng một kiểu khóa thống nhất cho các entity chính.
- Có navigation properties đầy đủ giữa các aggregate liên quan.
- Có enum cho trạng thái nghiệp vụ thay vì dùng chuỗi tự do.
- Có timestamps rõ ràng cho các hành vi quan trọng.
- Có soft delete hoặc cờ vô hiệu hóa cho dữ liệu cần audit.
- Có collection navigation ở phía aggregate root.

## Những gì cần làm để hoàn chỉnh từ A-Z

### A. Base domain

- Hoàn thiện `BaseEntity`.
- Chuẩn hóa audit fields, soft delete, timestamp policy.
- Thống nhất kiểu khóa giữa các entity.

### B. Business rules

- Xác định quy tắc khóa học được publish.
- Xác định điều kiện enroll, complete và cấp certificate.
- Xác định rule cho coupon, payment và refund.
- Xác định rule cho livestream và recording.

### C. Entities và quan hệ

- Rà soát toàn bộ entity và FK.
- Bổ sung collection navigation cho aggregate root.
- Bổ sung enum thay cho string status.
- Bổ sung ràng buộc dữ liệu cơ bản.

### D. DTO

- Tạo DTO cho tạo/sửa/xem chi tiết.
- Tách DTO public và DTO internal.
- Tách DTO cho admin, instructor và student.

### E. Validation

- Dùng FluentValidation cho input command/query.
- Validate giá, slug, email, rating, trạng thái và thời gian.
- Chặn dữ liệu không hợp lệ trước khi vào domain.

### F. Mapping

- Tạo mapping profile cho entity sang DTO.
- Chuẩn hóa naming field trong response.
- Giữ mapping tách biệt giữa các bounded context.

### G. Application layer

- Viết command/query theo từng nghiệp vụ.
- Tách service theo module.
- Áp dụng behavior pipeline nếu cần logging, validation, transaction.

### H. Persistence

- Thiết lập DbContext.
- Mapping EF Core cho toàn bộ entity.
- Cấu hình relationship, index, unique constraint.
- Chọn strategy xóa mềm và audit.

### I. Identity và auth

- Thiết lập đăng ký, đăng nhập, refresh token.
- Phân quyền admin, instructor, student.
- Xác thực email và reset password.

### J. API contract

- Định nghĩa route theo resource.
- Chuẩn hóa status code và error response.
- Thêm pagination, filtering, sorting.

### K. Security

- Bảo vệ password hash.
- Chống brute force và token abuse.
- Cấu hình CORS, JWT, rate limit.
- Kiểm tra quyền theo policy.

### L. Course management

- CRUD category.
- CRUD course.
- CRUD chapter và lesson.
- Upload video và tài liệu.
- Publish/unpublish course.

### M. Enrollment flow

- Student add course to cart.
- Checkout order.
- Payment success tạo enrollment.
- Track lesson progress.
- Issue certificate khi hoàn thành.

### N. Commerce flow

- Cart item management.
- Order calculation.
- Coupon apply/remove.
- Payment gateway integration.
- Refund flow nếu có.

### O. Notification

- Notification in-app.
- Event khi enroll, pay, complete, livestream start.
- Read/unread state.

### P. Livestream

- Schedule live session.
- Attach instructor và course.
- Store playback URL.
- Save recording after live end.

### Q. Quality assurance

- Unit test cho rule chính.
- Integration test cho API quan trọng.
- Test mapping, validation, auth.

### R. Observability

- Logging chuẩn.
- Error tracking.
- Audit log cho hành động quan trọng.

### S. Swagger và docs

- Mô tả endpoint.
- Mô tả request/response mẫu.
- Phân nhóm tag theo module.

### T. Deployment

- Tách appsettings theo môi trường.
- Chuẩn bị migration database.
- Chuẩn bị container hoặc IIS deploy.

### U. User experience for admin/instructor/student

- Admin dashboard.
- Instructor course dashboard.
- Student learning dashboard.
- Order and progress overview.

### V. Versioning

- Version API.
- Version schema nếu cần.
- Version các integration ngoài.

### W. Workflow

- Quy trình tạo course từ draft đến publish.
- Quy trình bán hàng từ cart đến payment.
- Quy trình học từ enroll đến certificate.

### X. XML/Docs/Export

- Export certificate.
- Export reports.
- Tài liệu API nội bộ.

### Y. Yield and maintainability

- Code style thống nhất.
- Không nhét business rule vào controller.
- Giữ domain độc lập khỏi infrastructure.

### Z. Zero-downtime mindset

- Chuẩn bị migration an toàn.
- Không phá contract cũ khi mở rộng.
- Dùng backward compatible change khi có thể.

## Roadmap triển khai

### Phase 1: Nền tảng

- Hoàn thiện Domain.
- Tạo DbContext và mapping EF Core.
- Tạo auth và role-based access.

### Phase 2: Khóa học

- Category, Course, Chapter, Lesson, Video, Resource.
- Publish course.
- Course detail API.

### Phase 3: Học tập

- Enrollment.
- Lesson progress.
- Review.
- Certificate.

### Phase 4: Thương mại

- Cart.
- Order.
- Payment.
- Coupon.

### Phase 5: Mở rộng

- Wishlist.
- Notification.
- Livestream.
- Analytics.

## Convention đề xuất

- Entity dùng PascalCase.
- FK rõ ràng, navigation property song song.
- Enum cho status/state.
- DTO đặt theo use case, không đặt theo entity thuần.
- Service tách theo module, không gom một service quá lớn.

## Chạy project

```bash
dotnet restore
dotnet build
dotnet run --project src/Be_Ktl.API
```

## Ghi chú

- README này là dàn ý chuẩn để phát triển tiếp dự án từ nền tảng hiện tại.
- Khi bắt đầu triển khai thật, nên chốt lại schema database, auth flow và module priority trước.


dotnet ef migrations add InitialCreate --startup-project ../Be_Ktl.API
dotnet ef database update --startup-project ../Be_Ktl.API 