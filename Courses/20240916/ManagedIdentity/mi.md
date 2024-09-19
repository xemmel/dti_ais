## Receipe for MI

```
(Both consumer and provider must be in same tenant (Entra))

- Enable MI on consumer (will create "user" in Entra)
- Assign Role Assignment to "user" on the provider data plane

```



#### System MI and User MI

```

System:
  - 1-1 with Azure Resource
  - Get a token, with no futher information
  - Deleted automatically when Azure Resource is deleted

User:
  - An Azure Resource itself
  - Many-to-many relation with actual Azure Resources
  - Created up front
  - Supply ClientId when using

```