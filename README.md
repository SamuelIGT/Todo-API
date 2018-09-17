# Todo API


<a name="overview"></a>
## Overview
A ASP.NET Core 2.0 REST API for a TODO application.


### Version information
*Version* : v1


### Contact information
*Contact* : Samuel Alves


<a name="models"></a>
## Models

<a name="todoitem"></a>
### TodoItem

|Name|Schema|
|---|---|
|**id**  <br>*optional*|integer (int64)|
|**isCompleted**  <br>*optional*|boolean|
|**name**  <br>*required*|string|



<a name="paths"></a>
## Paths

<a name="apitodopost"></a>
### Create a new TODO.
```
POST /api/todo
```


#### Description
Request example:
            
    POST /todo
    {
       "id": 1,
       "name": "Item1",
       "isComplete": true
    }


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Body**|**item**  <br>*optional*|[TodoItem](#todoitem)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**201**|Returns the todo item created|[TodoItem](#todoitem)|
|**400**|If the todo item is null|No Content|


#### Consumes

* `application/json-patch+json`
* `application/json`
* `text/json`
* `application/*+json`


#### Produces

* `application/json`


#### Tags

* Todo


<a name="apitodoget"></a>
### List all TODO items.
```
GET /api/todo
```


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**200**|Success|< [TodoItem](#todoitem) > array|


#### Produces

* `application/json`


#### Tags

* Todo


<a name="apitodobyidget"></a>
### List the TODO item of the corresponding id.
```
GET /api/todo/{id}
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Path**|**id**  <br>*required*|integer (int64)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**200**|Returns the expected TODO item|[TodoItem](#todoitem)|
|**404**|If no TODO item with the same id was found|No Content|


#### Produces

* `application/json`


#### Tags

* Todo


<a name="apitodobyidput"></a>
### Update a todo item.
```
PUT /api/todo/{id}
```


#### Parameters

|Type|Name|Description|Schema|
|---|---|---|---|
|**Path**|**id**  <br>*required*|TODO item ID|integer (int64)|
|**Body**|**item**  <br>*optional*|Todo item|[TodoItem](#todoitem)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**204**|Updated with success|No Content|
|**400**|If the item passed is null or its id is different from the onde passed on the url.|No Content|
|**404**|If no TODO item with the same id was found|No Content|


#### Consumes

* `application/json-patch+json`
* `application/json`
* `text/json`
* `application/*+json`


#### Tags

* Todo


<a name="apitodobyiddelete"></a>
### Delete a TODO item.
```
DELETE /api/todo/{id}
```


#### Parameters

|Type|Name|Schema|
|---|---|---|
|**Path**|**id**  <br>*required*|integer (int64)|


#### Responses

|HTTP Code|Description|Schema|
|---|---|---|
|**204**|Deleted with success|No Content|
|**404**|If no TODO item with the same id was found|No Content|


#### Tags

* Todo



