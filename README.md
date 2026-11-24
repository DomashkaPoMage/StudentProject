# Student Project

Учебный проект по дисциплине «Программная инженерия», оформленный как рабочий
репозиторий команды разработки интернет-магазина автозапчастей.

## Цель проекта

Разработать и автоматически поставлять веб-сервис каталога и заказа
автозапчастей, применяя планирование, ревью кода, тестирование и CI/CD.

## Основные возможности

- информация о состоянии сервиса (`GET /health`);
- описание каталога (`GET /`);
- расчёт стоимости корзины (`GET /cart/total`);
- автоматические тесты бизнес-логики;
- публикация проверенного Docker-образа.

## Быстрый запуск

Требуется .NET 10 SDK.

```powershell
dotnet run --project src/StudentProject.Web/StudentProject.Web.csproj --urls http://localhost:8080
```

После запуска доступны:

- `http://localhost:8080` — сведения о приложении;
- `http://localhost:8080/health` — проверка работоспособности;
- `http://localhost:8080/cart/total?price=1250&quantity=2` — расчёт корзины.

## Проверка

```powershell
dotnet build StudentProject.slnx --configuration Release
dotnet run --project tests/StudentProject.Tests/StudentProject.Tests.csproj --configuration Release
```

## Команда

| Участник | Роль | Зона ответственности |
| --- | --- | --- |
| [@muscateel123](https://github.com/muscateel123) | Product Owner / Project Lead | Планирование, приоритеты, архитектурные решения и приёмка результата |
| [@6Cerp9](https://github.com/6Cerp9) | Backend Developer | Бизнес-логика, корзина, оформление заказа и исправление серверных ошибок |
| [@andryxach123](https://github.com/andryxach123) | Frontend Developer | Каталог, поиск, интерфейс и пользовательские сценарии отслеживания заказа |
| [@BorisLarkin](https://github.com/BorisLarkin) | QA Engineer | Тест-кейсы, автоматические тесты, регрессионное тестирование и контроль качества |
| [@rigr1](https://github.com/rigr1) | DevOps & Integration Engineer | CI/CD, контейнеры, развёртывание и интеграции с внешними сервисами |

Ответственные за каталоги и конфигурационные файлы дополнительно закреплены в
`.github/CODEOWNERS`, поэтому при создании pull request GitHub сможет
автоматически запрашивать проверку у профильного специалиста.

## Используемые технологии

- ASP.NET Core и .NET 10;
- Git, GitHub Issues и GitHub Projects;
- GitHub Actions;
- Docker и GitHub Container Registry;
- Markdown и GitHub Wiki.

## Процесс разработки

Изменения выполняются в отдельных ветках и попадают в `main` через Pull Request.
Автоматическая проверка собирает приложение и запускает три теста. После успешной
проверки CI/CD создаёт артефакт, проверяет контейнер через `/health` и публикует
образ в GitHub Container Registry.

Подробности:

- [правила участия](CONTRIBUTING.md);
- [рабочий процесс команды](docs/development-workflow.md);
- [политика безопасности](SECURITY.md).

## Автоматизация

- [Лабораторная работа 4.0: обработчик сборочной линии](docs/lab-4.0-runner.md)
- [Лабораторная работа 4.1: непрерывная интеграция](docs/lab-4.1-continuous-integration.md)
- [Лабораторная работа 4.2: CI/CD как код](docs/lab-4.2-ci-cd-as-code.md)
