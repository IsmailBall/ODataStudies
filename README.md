# OData Studies

_Versions_: .Net 6, OData 8

__Topics__ :

- __Implemtation__: 
    -   Method
        ``` sh
            static IEdmModel GetEdmModel()
            {
                ODataConventionModelBuilder builder = new();
                builder.EntitySet<Product>("Products");
                builder.EntitySet<Category>("Categories");
                return builder.GetEdmModel();
            }
        ```
    -   Service
        ``` sh
            builder.Services.AddControllers().AddOData(options =>
            {
                options.AddRouteComponents("odata", GetEdmModel()).Select();
            });
        ```
- __Inherited Controller Class:__
    - For controllers
    ``` sh 
        ODataController
    ```
- __Attributes:__
    - For methods
    ``` sh 
        [EnableQuery]
    ```

<br/>

# QUERYING

__Raw DATA__
![ODATA1](https://user-images.githubusercontent.com/89700270/175551223-0bb52bb0-6e0a-4440-99d6-87344d3df8b0.PNG)

- Select
    - Ex: 
    ``` sh
        http://localhost:5187/odata/products?$select=Id,Name,Stock
    ``` 
    __With Select:__
    ![ODATA2](https://user-images.githubusercontent.com/89700270/175551628-733eda7e-8c39-44cf-b358-ee9fba1312c3.PNG)
