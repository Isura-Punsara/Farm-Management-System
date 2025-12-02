# Farm Management System — Farm

Tech: C#, .NET (Visual Studio), Windows Forms, SQL Server (SqlServerTypes), RDLC reports, NuGet (packages.config)

This folder contains the Farm module/application of the Farm-Management-System repository. The contents are based on the project and source files present in this directory.

## Key files and folders
- Farm.sln
- Farm.csproj
- packages.config
- App.config
- Program.cs
- folders observed: .vs, bin, obj, Properties, Resources, SqlServerTypes

## Source and UI files
- Windows Forms source files (.cs) with their designer and resource files:
  - Login.cs / Login.Designer.cs / Login.resx
  - Signup.cs / Signup.Designer.cs / Signup.resx
  - Many form implementations and designer files (e.g. fmaniprof.*, fmaniproup.*, fmprof.*, fmsupprof.*, fmtsk.*, fmexp.*, fmrecsup.*, fmrecsup.*, updateusers.*, Viewusers.*, and many che* / cheenv* / cheeq* files)
- Program entry: Program.cs
- Numerous .Designer.cs and .resx pairs indicating WinForms UI components

## Data, schema, and typed datasets
- XSD / XSC / XSS and dataset files for reports/data bindings:
  - BreedingData.xsd / BreedingData.xsc / BreedingData.xss / BreedingData.cs / BreedingData.Designer.cs
  - FeedingData.xsd / FeedingData.xsc / FeedingData.xss / FeedingData.Designer.cs
  - SupplierData.xsd / SupplierData.xsc / SupplierData.xss / SupplierData.Designer.cs
  - Additional data/designer files seen across the project

## Reporting
- RDLC report files and report viewers:
  - Breeding Report.rdlc
  - FeedingReport.rdlc
  - SupplierReport.rdlc
  - Report1.rdlc
  - Many report-related form files and report viewer code (e.g. Crepviewer.* and many *rep.* files)

## Domain areas / modules (inferred from filenames)
The following modules are present in the repository by file name:
- Authentication: Login, Signup
- Breeding (BreedingData.*, breeding report, breedreportview.*)
- Feeding (FeedingData.*, FeedingReport.rdlc, feedreportview.*)
- Suppliers and Supplier reporting (SupplierData.*, SupplierReport.rdlc, sup* files)
- Veterinary / Health (vet* files: vetbred*, vetheal*, vetmedinv.*, vettreat.*, vetvac.*, vetvetvis.*)
- Inventory and inventory reports (fminv*, fminvrep.*)
- Finance and financial reports (finadata.*, finreport.*)
- Employee management and reports (emp* / empreport.*)
- Profiles and user management (fmprof.*, fmaniprof.*, updateusers.*, Viewusers.*)
- Tasks, schedules and attendance (fmtsk*, fmtaskrep.*, supatten.*, fmfedsch.*, fmmonatt.*)
- Miscellaneous reporting and report viewers (many che*, cusreport.*, sup* reports)

## File types present
- C# source and WinForms UI: .cs, .Designer.cs
- Resources: .resx
- Report definitions: .rdlc
- Typed datasets / XML schema: .xsd, .xsc, .xss
- Solution/project: .sln, .csproj
- NuGet package list: packages.config

## Notes
- This README reflects only the files and filenames present in the Farm/Farm directory of the repository.
- The contents were derived from project files (filenames and file metadata). The listing used to generate this README may be incomplete due to API listing limits — view the directory in GitHub for the full contents:
  https://github.com/Isura-Punsara/Farm-Management-System/tree/main/Farm/Farm
