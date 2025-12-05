
---
# 🐄 Farm Management System — Meat Farm Operations (WinForms + SQL Server)

![GitHub repo size](https://img.shields.io/github/repo-size/Isura-Punsara/Farm-Management-System?color=green)
![GitHub contributors](https://img.shields.io/github/contributors/Isura-Punsara/Farm-Management-System)
![Platform](https://img.shields.io/badge/Platform-Windows%20Forms-lightgrey)
![Database](https://img.shields.io/badge/Database-SQL%20Server-orange)
![Reports](https://img.shields.io/badge/Reports-RDLC-yellow)


A complete Windows Forms–based Farm Management System built for a meat-production farm.  
The system manages breeding, feeding, suppliers, veterinary care, inventory, employees, finance, tasks, attendance, and detailed RDLC reports.

This repository contains the full Farm Management System, including all major modules and the underlying Farm application located inside the `Farm/Farm` folder.

---

## 📌 Tech Stack
- **Frontend:** Windows Forms (.NET Framework)
- **Backend:** SQL Server / SQL Express
- **Reporting:** RDLC Reports
- **IDE:** Visual Studio 2019 or later
- **Other:** Report Viewer Runtime, NuGet Packages

---

## 📂 Project Structure
Farm-Management-System/
│
├── Farm/
│   └── Farm/              ← Main WinForms Application
│       ├── *.cs           (Code-behind files)
│       ├── *.Designer.cs  (UI Designer)
│       ├── *.resx         (Resources)
│       ├── *.rdlc         (Reports)
│       ├── *.xsd          (Typed Datasets)
│       ├── Farm.sln       (Solution)
│       ├── Farm.csproj    (Project)
│       └── SqlServerTypes/(SQL Client Types)
│
└── README.md

---

## ✨ System Overview
A robust desktop application designed to manage the full lifecycle of a meat farm’s operations:

- ✔ Breeding & animal lineage  
- ✔ Feeding schedules and consumption  
- ✔ Supplier management  
- ✔ Veterinary care & medical inventory  
- ✔ Employee records & attendance  
- ✔ Task management  
- ✔ Inventory tracking  
- ✔ Finance & expenses  
- ✔ RDLC reporting for every domain  
- ✔ Login, Signup, User roles  

---

## 📘 Main Features (Full System)

### 🔐 1. Authentication Module
- Files: `Login.*`, `Signup.*`  
- Secure login & signup  
- User validation  
- Profile initialization  

### 👤 2. User & Profile Management
- Files: `fmprof.*`, `fmaniprof.*`, `fmaniproup.*`, `updateusers.*`, `Viewusers.*`  
- Create / update / delete user accounts  
- Manage user groups & permissions  
- Search and filter users  
- Profile picture & personal info  

### 🐄 3. Animal Breeding Management
- Files: `BreedingData.*`, `Breeding Report.rdlc`, `breedreportview.*`  
- Record breeding cycles  
- Breeding history  
- Generate breeding RDLC reports  
- Typed datasets for reporting  

### 🥩 4. Feeding Management
- Files: `FeedingData.*`, `FeedingReport.rdlc`, `fmfedsch.*`, `fmfedcun.*`  
- Feeding schedules  
- Consumption tracking  
- Feed stock usage  
- Feeding reports  

### 🚚 5. Supplier Management
- Files: `SupplierData.*`, `SupplierReport.rdlc`, `sup*.*`  
- Supplier details  
- Supplier attendance  
- Supplier deliveries  
- Supplier feeding & health contributions  
- Reports for each  

### 🐑 6. Veterinary & Health Module
- Files: `vetbred*`, `vetheal*`, `vetmedinv.*`, `vettreat.*`, `vetvac.*`  
- Animal treatments  
- Vaccination schedules  
- Veterinary visits  
- Medical inventory  
- Health reports (RDLC)  

### 📦 7. Inventory Management
- Files: `fminv.*`, `fminvrep.*`  
- Equipment  
- Feed  
- Medical supplies  
- Stock levels  
- Inventory valuation  
- Inventory reports  

### 💰 8. Finance & Expense Tracking
- Files: `finadata.*`, `finreport.*`  
- Farm expenses  
- Supplier payments  
- Financial summaries  
- RDLC finance reports  

### 👥 9. Employee Management
- Files: `emp*`, `empreport.*`  
- Employee profiles  
- Role assignment  
- Leave & attendance  
- Employee performance reports  

### 🗓️ 10. Tasks, Schedules & Attendance
- Files: `fmtsk.*`, `fmtaskrep.*`, `fmmonatt.*`, `suptask.*`, `supatten.*`  
- Daily tasks  
- Task assignment  
- Attendance monitoring  
- Reports for attendance  
- Task summaries  

### 📑 11. Reporting System (RDLC)
- Files: Many `*.rdlc`, `*rep.*`, `*report.*`, `Crepviewer.*`  
- RDLC report definitions  
- Report viewer forms  
- Data-bound datasets  
- Export to PDF/Excel (default ReportViewer capabilities)  

### 🧪 12. Miscellaneous Modules
- Files: `cheenv*`, `cheeq*`, `chemed*`  
- Environmental checks  
- Equipment checks  
- Chemical or medicine logs  
- Associated reports  

---

## 🛠️ How to Run the Project

### 1. Requirements
- Visual Studio 2019 or later  
- .NET Framework installed  
- SQL Server / SQL Express  
- Report Viewer Runtime (VS usually installs it)  

### 2. Steps
1. Clone repository  
2. Open `Farm/Farm/Farm.sln`  
3. Restore NuGet packages  
4. Ensure SQL Server connection string in `App.config` is valid  
5. Build & run  
