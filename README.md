**Assignment #3 - Authentication API:**

Built With
-.net8 Api

Solution structure:
We have four layers as below:
1-Infastructure
2-Entities
3-Service
4-API

Run the solution
-Run the solution will open the swagger, nav to seed controller from there run the post action this will generate new user (email: a.albakri@Gmail.com password: P@ssw0rd)
-Use the creds to login in the account controller in the login api this action will generate JWT token, use this token to validate the access to the **test-authorization** Action in Account controller 
**(make sure to put Token in the headers)**
-I Add **RoleAndRightAuthorizationAttribute** attribute which will check if the user is authorized or not.
