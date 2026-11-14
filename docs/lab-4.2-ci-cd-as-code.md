# Лабораторная работа 4.2: CI/CD как код

## Цель

Описать полный процесс сборки, тестирования и поставки приложения в YAML-файле,
хранящемся вместе с исходным кодом.

## Реализация в GitHub

Конвейер находится в `.github/workflows/ci-cd.yml` и содержит два зависимых
этапа.

### Этап Build

1. Получает исходный код.
2. Устанавливает .NET 10 SDK.
3. Восстанавливает зависимости и собирает решение.
4. Выполняет три автоматических теста.
5. Публикует ASP.NET Core-приложение.
6. Формирует артефакт `build-drop`, содержащий приложение, результаты тестов,
   Dockerfile и манифест поставки.

### Этап Deploy

1. Запускается только после успешного этапа Build.
2. Загружает тот же артефакт `build-drop`.
3. Создаёт контейнер приложения.
4. Запускает контейнер и проверяет адрес `/health`.
5. Публикует проверенный образ в GitHub Container Registry с тегами хеша
   коммита и `latest`.
6. Фиксирует поставку в среде GitHub `production`.

## Аналоги Azure DevOps

| Azure DevOps | GitHub |
| --- | --- |
| `azure-pipelines.yml` | `.github/workflows/ci-cd.yml` |
| Stage Build | Задание `build` |
| Stage Deploy | Задание `deploy` |
| Publish Build Artifacts | `actions/upload-artifact` |
| Download Build Artifacts | `actions/download-artifact` |
| Azure App Service | GitHub Container Registry |
| Переменные конвейера | Раздел `env` |
| Среда развёртывания | GitHub Environment `production` |

## Контроль результата

Успешный запуск должен содержать два зелёных задания: **Build - сборка и
тестирование** и **Deploy - публикация контейнера**. В запуске должен быть
доступен артефакт `build-drop`, а в пакетах организации - контейнер
`studentproject`.
