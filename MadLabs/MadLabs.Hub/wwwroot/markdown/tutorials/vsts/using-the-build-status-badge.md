<!-- 
<metadata>
    <summary value="This tutorials shows how to use the VSTS build badge API. "/>
    <title value="Using VSTS Build Badges on GitHub."/>
    <order value="6"/>
    <author value="Mathieu St-Louis"/>
</metadata>
-->


# Integrating VSTS Build Status Badge on GitHub Repo

## Summary
In this tutorial, we'll integrate a VSTS build badge into a GitHub readme.md file.

Example of build status badge



### Prerequisites
 - Setup a build definition.


### Step 1 - Get the Build Status Badge GET request.
There's several different ways to access the badge API, but the easiest by far is to copy paste the GET request provided in the build definition.

1. Go to your build definition

2. Enabled the **Badge enabled** field and save the build definition

3. A text field will appear under the **Badge enabled** checkbox. That's your GET request for the badge! Copy it.


### Step 2 - Integrate badge in GitHub readme.md.

1. Put the Badge GET request in your project's readme.md.
