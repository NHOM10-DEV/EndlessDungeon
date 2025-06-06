🛠️ Yêu cầu trước khi bắt đầu
Trước khi cài đặt project từ GitHub, bạn cần:

Tài khoản GitHub: Đăng ký tại https://github.com

Tải và cài GitHub Desktop:
Link tải: https://desktop.github.com/

📥 Bước 1: Tải Project từ GitHub về bằng GitHub Desktop
Cách 1: Clone từ GitHub bằng link
Vào trang GitHub của project bạn muốn cài đặt. (VD: https://github.com/user/project-name)

Nhấn nút Code → chọn HTTPS → bấm nút 📋 để sao chép đường link

Mở GitHub Desktop

Chọn File → Clone Repository

Trong tab URL, dán đường link vừa copy vào.

Chọn thư mục nơi bạn muốn lưu project → nhấn Clone

Cách 2: Mở thẳng từ trang GitHub
Trong trang GitHub của project, bấm nút Code

Chọn Open with GitHub Desktop

Trình duyệt sẽ hỏi bạn mở ứng dụng GitHub Desktop → chọn Cho phép

GitHub Desktop sẽ mở với cửa sổ "Clone a repository" → chọn thư mục lưu → Clone

📂 Bước 2: Mở Project vừa tải
Sau khi clone xong:

Nhấn nút Open in Visual Studio Code (hoặc Open in Explorer để mở thư mục).

Bạn có thể chỉnh sửa, chạy code hoặc build tùy theo loại project.

▶️ Bước 3: Chạy project (tuỳ theo loại)
Tùy vào loại project, cách chạy sẽ khác nhau. Ví dụ:

🔹 Với project Node.js:
Mở terminal trong thư mục project

Chạy:

bash
Sao chép
Chỉnh sửa
npm install
npm start
🔹 Với project Unity:
Mở Unity Hub → chọn Open → dẫn tới thư mục project vừa clone

🔹 Với project Python:
Mở terminal → chạy:

bash
Sao chép
Chỉnh sửa
pip install -r requirements.txt
python tên_file_chính.py
🔄 Bước 4: Cập nhật code khi có thay đổi
Trong GitHub Desktop, bạn sẽ thấy các commit mới nếu project đã thay đổi.

Nhấn nút Fetch origin → rồi nhấn Pull để cập nhật về máy.

📝 Bước 5: Thay đổi và đẩy code lên lại (nếu bạn có quyền)
Sau khi chỉnh sửa code, bạn sẽ thấy danh sách file thay đổi ở GitHub Desktop.

Nhập message commit ngắn gọn (VD: Sửa bug đăng nhập)

Nhấn Commit to main

Nhấn Push origin để đẩy code lên GitHub

⚠️ Bạn chỉ có thể push nếu bạn là người tạo repo hoặc được cấp quyền collaborator.
