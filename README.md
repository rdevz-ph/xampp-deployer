# 🛠 XAMPP Web Project Deployer (WinForms)

A lightweight Windows Forms utility that extracts a web project (ZIP) into `xampp/htdocs`, creates a desktop shortcut to access the deployed website, and automatically launches it in Google Chrome.

---

## 🚀 Features

- 📂 Select a `.zip` file of your PHP website project
- 📦 Automatically extracts it to `C:\xampp\htdocs\{YourProjectName}`
- 🌐 Launches the site in Chrome at `http://localhost/{YourProjectName}`
- 🔗 Creates a desktop shortcut with a **custom name** to your local site

---

## 🧩 Requirements

- Windows 10/11
- [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-web-installer)
- [XAMPP](https://www.apachefriends.org/index.html)
- Google Chrome (installed at the default path)

---

## 📥 How to Use

1. Download or clone the repository:
   ```bash
   git clone https://github.com/rdevz-ph/xampp-deployer.git
   ```

2. Open the solution in **Visual Studio**

3. Make sure to:
   - Add a reference to **Windows Script Host Object Model** (COM)
   - Add a reference to `Microsoft.VisualBasic` (for the input dialog)

4. Build and run the application

5. Click **"Deploy Website"**
   - Select your `.zip` file
   - Enter a custom shortcut name
   - App will extract, launch in Chrome, and create a desktop shortcut

---

## 📄 Notes

- If `C:\xampp\htdocs\{ProjectName}` already exists, it will be replaced.
- This app is ideal for developers who frequently test local PHP projects using XAMPP.

---

## 🧑‍💻 Author

**Romel Brosas**  
Freelance Full-Stack Developer  
🌐 [https://github.com/rdevz-ph](https://github.com/rdevz-ph)

---

## 📝 License

MIT License. You are free to use, modify, and distribute this tool.
