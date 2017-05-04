# T1464FinalProject

> Source code for my Programming for Business (T1464) final project entry.

## About

This is the source code for the final project entry of my Web-Based Programming (M0114) course. Slightly modified so it works on newer Visual Studio & SQL Server versions. I'm not sure if this is the version we submitted, or the actual finished version (because we ended up losing a day's worth of work for whatever reason).

## The Team

* Resi Respati - 1701327592
* Lazuardi Ridho Maulana - 1701321241

## Developing & running locally

### Requirements

* Visual Studio 2015 Community (The original project was written in 2010, but I recently made it work for VS2015).
* Microsoft SQL Server 2014 Express (Same thing, originally developed in an older version of SQL Express).

### Clone the project

You can clone the project directly from Visual Studio 2015 (I forgot how, but you should be able to figure it out).

### Attaching the database

Before debugging and running the app, make sure you have attached the included database files (`Database1.mdf` and `Database1_log.ldf`) to your Microsoft SQL Server instance, and connect to it from Visual Studio. Here's how you do it.

* Open SQL Server Management Studio, select the `Databases` node, right click it and select `Attach...`
* Provide the path for the `.mdf` file, click OK and then you should be good to go.
* Inside Visual Studio 2015, open Server Explorer (menu `View -> Server Explorer`), right click `Data Connections` and then select `Add Connection...`.
* Make sure your Data Source is set to `Microsoft SQL Server (SqlClient)`
* In Server name: put `.\SQLEXPRESS` and in `Connect to a database:` select the database you attached previously.
* Click on `Advanced...`, and in `Data Source` change the value to `.\SQLEXPRESS`.

**Source:** https://stackoverflow.com/a/16431699/3526811

## Project Requirements

See the attached doc file ([`E2-T1464-CF01-00.docx`](E2-T1464-CF01-00.docx)) for the project requirements.

## License

[Unlicense](LICENSE).