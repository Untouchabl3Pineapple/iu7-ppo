# Переменные
PROJECT_NAME = db_cp
CONFIGURATION = Release

# Определение целей и правил
build:
	dotnet build --configuration $(CONFIGURATION) $(PROJECT_NAME).csproj

clean:
	dotnet clean --configuration $(CONFIGURATION) $(PROJECT_NAME).csproj

run:
	dotnet run --configuration $(CONFIGURATION) --project $(PROJECT_NAME).csproj

publish:
	dotnet publish --configuration $(CONFIGURATION) --output ./publish

.PHONY: build clean run publish