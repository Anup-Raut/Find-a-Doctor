# Find-a-Doctor
# 🏥 Find a Doctor - Healthcare Consultation Platform

<div align="center">

![ASP.NET](https://img.shields.io/badge/ASP.NET-Core-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Razor Pages](https://img.shields.io/badge/Razor-Pages-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.1.1-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
![PayPal](https://img.shields.io/badge/PayPal-Integration-00457C?style=for-the-badge&logo=paypal&logoColor=white)

**A comprehensive healthcare platform connecting patients with qualified doctors**

[Features](#-features) • [Tech Stack](#-tech-stack) • [Getting Started](#-getting-started) • [Project Structure](#-project-structure) • [Screenshots](#-screenshots)

</div>

---

## 📋 Overview

**Find a Doctor** is a modern healthcare consultation platform built with ASP.NET Core Razor Pages. The application facilitates seamless communication between patients and doctors, enabling online consultations, medical report uploads, and secure payment processing through PayPal integration.

## ✨ Features

### 👤 Patient Portal
- **User Registration & Authentication** - Secure email-based registration system
- **Doctor Search** - Advanced search functionality by specialization, state, and city
- **Consultation Management** - View consultation history and track ongoing consultations
- **Medical Reports Upload** - Upload medical documents (PDF files up to 1MB)
- **Secure Payments** - Integrated PayPal payment system for consultation fees
- **Real-time Communication** - Message doctors and receive responses

### 👨‍⚕️ Doctor Portal
- **Professional Dashboard** - Comprehensive view of all consultations
- **Profile Management** - Manage specialization, clinic details, and fees
- **Consultation Response** - Review patient messages and medical reports
- **Patient History** - Access complete consultation history with each patient
- **Status Management** - Mark consultations as completed or pending

### 🔐 Security Features
- Role-based authentication (Doctor/Patient)
- Secure session management
- Password encryption
- Protected file uploads

## 🛠️ Tech Stack

### Backend
- **Framework**: ASP.NET Core (Razor Pages)
- **Language**: C# 
- **Architecture**: Model-View-Controller (MVC) with Razor Pages
- **Session Management**: Built-in ASP.NET Core Session State

### Frontend
- **UI Framework**: Bootstrap 5.1.1
- **CSS**: Custom Bootstrap theming
- **Icons**: Bootstrap Icons
- **Responsive Design**: Mobile-first approach

### Payment Integration
- **Payment Gateway**: PayPal REST API
- **Transaction Tracking**: Unique PayPal transaction IDs
- **Security**: Secure payment processing with transaction verification

### File Management
- **Supported Formats**: PDF
- **Storage**: Server-side file storage
- **Validation**: File size and type validation
- **Security**: Secure file upload and retrieval

## 📁 Project Structure

```
MyRazorApp/
├── Pages/
│   ├── Models/
│   │   ├── ClinicLocations.cs
│   │   ├── Consultation.cs
│   │   ├── DoctorProfile.cs
│   │   ├── LoginInfo.cs
│   │   ├── PatientProfile.cs
│   │   ├── ProjectContext.cs
│   │   ├── RegistrationInfo.cs
│   │   └── Specialization.cs
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   ├── _ViewImports.cshtml
│   │   └── _ViewStart.cshtml
│   ├── Index.cshtml
│   ├── Login.cshtml
│   ├── Register.cshtml
│   └── [Other Pages...]
├── wwwroot/
│   ├── Areas/
│   ├── Database/
│   └── [Static Assets]
├── appsettings.json
├── Program.cs
└── Startup.cs
```

## 🚀 Getting Started

### Prerequisites
- .NET 6.0 SDK or later
- Visual Studio 2022 or VS Code
- SQL Server (LocalDB or Express)
- PayPal Developer Account (for payment integration)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/find-a-doctor.git
   cd find-a-doctor
   ```

2. **Configure the database**
   - Update connection string in `appsettings.json`
   - Run database migrations (if applicable)

3. **Configure PayPal**
   - Add your PayPal API credentials to `appsettings.json`
   - Set up PayPal sandbox for testing

4. **Restore dependencies**
   ```bash
   dotnet restore
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

6. **Access the application**
   - Navigate to `https://localhost:44358` in your browser

## 💡 Key Features Breakdown

### Registration System
The platform supports dual registration for both doctors and patients with automatic password generation based on email addresses.

### Smart Doctor Search
Patients can search for doctors using multiple criteria:
- Medical specialization (Cardiologist, Neurologist, etc.)
- Geographic location (State and City)
- Availability and fees

### Consultation Workflow
1. Patient searches and selects a doctor
2. Patient pays consultation fee via PayPal
3. Patient submits symptoms and uploads medical reports
4. Doctor reviews consultation and responds
5. Both parties can track consultation status

### Payment Integration
- Secure PayPal integration for consultation fees
- Automatic transaction ID generation
- Payment verification before consultation submission
- Transaction history tracking

## 📸 Screenshots

The application includes:
- Clean, modern registration interface
- Intuitive patient dashboard with consultation history
- Comprehensive doctor consultation view
- Easy-to-use doctor search with filters
- Professional doctor dashboard

## 🔮 Future Enhancements

- [ ] Video consultation integration
- [ ] Prescription management system
- [ ] Appointment scheduling calendar
- [ ] SMS/Email notifications
- [ ] Multi-language support
- [ ] Advanced analytics dashboard
- [ ] Mobile application (iOS/Android)
- [ ] Integration with electronic health records (EHR)

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Authors

- **Anup Raut** 

## 🙏 Acknowledgments

- Bootstrap for the amazing UI framework
- PayPal for payment processing
- The ASP.NET Core team for the excellent framework

---

<div align="center">

**Made with ❤️ for better healthcare accessibility**

[⬆ back to top](#-find-a-doctor---healthcare-consultation-platform)

</div>
