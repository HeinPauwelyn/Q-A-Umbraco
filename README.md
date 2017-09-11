# Q&A Umbraco

> Simple demo with custom controllers using Umbraco

## What's made?

1. Create custom controllers.
2. Add custom data on front website.
3. Mannage content (just delete content) on the back website (the Umbraco CMS).

## How it's made?

### Controller

Just add a controller named `QuestionController` to the folder `Controllers`. This must extends from `SurfaceController` and write your actions.

### Question Managing System

#### The editor

Create a new plugin under the folder `App_Plugins` named `QuestionList`. Inside the manifest file add this code:

```json
{
	"propertyEditors": [
		{
            "alias": "ALaQAndA.WebApp.Plugins.QuestionsList",
            "name": "Questionslist",
			"icon": "icon-item-arrangement",
			"group": "custom editors",
            "editor": {
                "view": "~/App_Plugins/QuestionsList/backoffice/questionTree/overviewQuestion.html",
                "hideLabel": true,
                "valueType": "JSON"
            }
        }
	],
	"parameterEditors": [],
	"javascript": [
		'~/App_Plugins/QuestionsList/Resources/question.resource.js',
		'~/App_Plugins/QuestionsList/Controller/question.overview.controller.js'
	],
	"css": []
}
```

Under the folder `Tree`, is an controller added named `QuestionTreeController` extending from `TreeController`.

#### The API calls

This will add an editor inside the document types.

To load the questions inside the view, request the data from this URL: `backoffice/{servicename?}/{controllername}/{actionname}` for example: `backoffice/Questions/QuestionsApi/GetAll`. For this an extra controller is added named `QuestionsApiController` extending from `UmbracoAuthorizedJsonController`.

