<!-- 
<metadata>
    <summary value="This tutorials shows how to use the VSTS build badge API. "/>
    <title value="Triggering VSTS Build in GitHub PR."/>
    <order value="5"/>
    <author value="Mathieu St-Louis"/>
</metadata>
-->

# Triggering VSTS Builds in GitHub Pull Requests

### Summary
In this tutorial, we will see how to trigger VSTS builds whenever a pull request is created. We will also set up a checkin gate in order to prevent merging of failing build into master.

### Prerequisites
 - Created a VSTS Build definition.


### Step 1 - Create a new PR-only VSTS build definition
1 - Clone your rolling build definition and give it an appropriate name, such as MyProject-Master-PR.

2 - Edit your newly cloned PR build definition, and go to the **Trigger** tab.

3 - Under **Pull Request Validation**, check the **Enable Pull Request Validation** checkbox.


### Result

