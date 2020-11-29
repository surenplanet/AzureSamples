1. In Azure Shell, create redis using Redis command
REDIS_NAME=[name]

az redis create \
    --name "$REDIS_NAME" \
    --resource-group learn-ba71db04-cff9-4c6b-9900-f04524896214 \
    --location eastus \
    --vm-size C0 \
    --sku Basic


2. dotnet add package ServiceStack.Redis