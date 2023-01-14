# AWSTicketingDemo2

Bare bones, sorry didn't get much time to work on it during the week.

Things left to do:
- integrate the authentication provider to the web api/serverless function via a filter in the entry point/startup.cs and add some authorise decorators to the web api's to ensure it is used.
- I have a principle of minimal code in the controller/function so would like to extract away the code for connecting and writing to mongodb
- nice to have - move the okta credentials out of appsettings into environment variables
- performance will be improved by connection pooling the mongodb connections in some way in the serverless function
- there wasn't much info when listing file uploads whether you wanted to take this from the s3 bucket or the mongodb, so in teh absence of instructions I took from s3 bucket. 
- there probably needs to be a discussion on what properties of the file uploads you need to list, and then make a class to serialise to json to return this specific data, currently it only returns the key
- test everything (currently only okta fully tested)
- what you can't see is the trigger in my aws subscription to link the serverless function to my s3 bucket, there's probably a way of doing this trigger in code but I haven't researched that yet.
- general tidy up and make is according to solid design principles as this is a first draft only and not optimised.
