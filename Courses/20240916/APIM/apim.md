## Architecture

- API Management Service (Azure Resource)     (Gateway endpoint)
    - API      -> Backend API
        - Operations
             - Method (GET, POST) (url)
        - Operations
    - API
    - API


### Secure API with "Entra"/OAuth2


```xml

<validate-jwt header-name="Authorization" failed-validation-httpcode="401" failed-validation-error-message="Unauthorized. Access token is missing or invalid.">
    <openid-config url="https://login.microsoftonline.com/adminintegrationit.onmicrosoft.com/.well-known/openid-configuration" />
    <audiences>
        <audience>api://e876b182-bb74-43e9-a0cd-3f303c712b66</audience>
    </audiences>
    <required-claims>
        <claim name="roles" match="all">
            <value>weatherexecuter</value>
        </claim>
    </required-claims>
</validate-jwt>

```