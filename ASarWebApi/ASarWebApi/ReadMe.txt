1. Meke sure all nugget packages are installed
2.In ASarWebApi/Web.config put a valid connection string to SQL like this
	<add name="UsersDB" connectionString="metadata=res://*/UserContext.csdl|res://*/UserContext.ssdl|res://*/UserContext.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(local);initial catalog=Users;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework&quot;" providerName="System.Data.EntityClient" />
3. Open the command window (views/other windows/ command window) and put Update-DataBase to create the database with the model (UserModel) in AsarWebApi/Models/UserModel.cs
4. Use PostMan or TestMan to test the WebApi 
5. Enjoy =)