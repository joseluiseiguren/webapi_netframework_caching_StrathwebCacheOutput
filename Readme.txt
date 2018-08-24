EndPoints
	GET: http://localhost:60388/api/persons
	GET: http://localhost:60388/api/persons/1
	DELETE: http://localhost:60388/api/persons/1 (este invalida el cache)
	
Poner esta entrada en el header de los GET (el valor es el ETAG que devolcio el 1er request)	
	If-None-Match:W/"a76c6c9a5aa7450aa8d0516dcce6c247"

Packages NuGet
	Strathweb.CacheOutput.WebApi2