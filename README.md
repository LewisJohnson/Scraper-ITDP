# Scraper-ITDP
 
## Build
### Backend

The .NET API must be run using IIS or Kestrel, using Port 3000.
Alternatively you may modify the URL used in main.js

You can configure and run the API from either the CLI or Visual Studio 2019.
### Frontend

The VueJS must use Port 8080 otherwise you will get a CORS error.
Alternatively you may modify the URL used in ScraperApi::api::Startup.cs

The frontend does use a few npm packages, notably, Vue.JS, Axios and Bootstrap. These dependencies must be installed via the CLI using npm. You may then serve or deploy the app hassle free... hopefully. 
