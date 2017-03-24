This project is built in VS2015 with .net framework 4.6

pre-requisities:
	1. VS 2015,
	2. .Net framework 4.6 or above

brief about the project :

1. this .net app is created for API to save data to DB and hosted the html files for the sake of avoiding CORS.(we can fix by enabling cors at server  side and modifyin webix api to handle preflight requests.)

2. a LOCAL SQL MDF file is selected for DB operations and it is incluldedd in the project.

3. webix client is included in the project under scripts/codebase folder

4. no other UI frameworks are used except WEBIX.

5. the project is set to open index.html file instead of default serverpage. if it goes to default page please redirect to index.html.

6. after clicking the save button, we need to wait until the green "tick" image loads to goto next page.

7. lot of packages are loaded by default which are not required. need to clean up.



assumptions:
	1. no proper Schema is defined for EXCEL, 4 columns have been considered and if not provided, automatically adding empty rows
	2. last updated records to be available on top for editing.
	3. Only one row must be edited at any given time.

todo items:
1. it can be easily converted to repository pattern to change the repository to file/DB server/any source.
2. can be extended the webix to handle CORS, to decouple the API from webclient (HTML pages)
3. A schema can be defined in EXCEL and can be used in conjunction with .INI file to use OLE provider to import data to data source.
4. Recording editor page can be decoupled from fixed schema by using MONGODB to store any EXCEL data instead of constraining to a specific SCHEMA.
5. UNIT Testing the api.
6. Security needs to implented at API level.
7. proper error and exception handling.
8. code cleanup.


