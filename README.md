- Hiện tại có 2 app:
+ 1 app sử dụng C# winform (UHFReader288Demo_eng V6.1) có giao diện để đọc tag RFID, config Reader, nhận tín hiệu từ cảm biến để xử lý bật tắt reader.
+ 1 asp .Net (apiApp) để viết các API như anh Trí yêu cầu: gửi mã epc của tag RFID đã đọc được, các thao tác xóa dữ liệu đã đọc (xóa 1 dữ liệu, xóa toàn bộ dữ liệu), bật tắt đèn báo hiệu,...
+ 2 app kết nối với nhau thông qua giao thức SignalR để truyền dữ liệu giữa 2 app.
- Vấn đề hiện tại:
+ Bị lỗi chỉ đọc được 1 antenna.
+ Anh Trí yêu cầu gộp 2 app lại, chỉ cần chạy 1 app service vừa đọc được dữ liệu từ reader vừa đồng thời tích hợp được cả các api mà đã yêu cầu trước đó. Anh trí chỉ call qua api service để điều khiển reader và các thiết bị ở cổng.
