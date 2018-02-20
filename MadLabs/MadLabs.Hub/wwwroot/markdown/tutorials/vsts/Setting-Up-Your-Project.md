<!-- 
<metadata>
    <summary value="Creating project"/>
    <title value="MyTitle"/>
    <order value="2"/>
</metadata>
-->

### Step 1 - Create a new project in VSTS

This step is pretty straightforward.
1.  Go on {yourAccountName}.visualstudio.com and click on "Create new project".



### Step 2 - Adding collaborators

Any collaborators wanting to contribute to your project will need to be present in your AAD.
In order to add collaborators, do the following

1. Log in the Azure Portal
2. Go to Azure Active Directory -> Users
3. Click **+ New Guest User**
>**Hint**: Guest users differs from normal users by allowing different domains, such as @gmail.com, @hotmail.com, etc..

4. Write in the email of the person you want to invite.


5. Go back to your project on VSTS.
6. Go to the upper right corner of the screen click the + under the **Members** section


### VSTS as a CI platform
Since we're hosting our project on GitHub, we won't push any code into our new project. We will be using VSTS exclusively for CI.