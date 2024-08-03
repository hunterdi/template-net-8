### Migrations
- Remove-Migration -p Infrastructure -c PostgresDBContext -Force
- Add-Migration InitialCreate -p Infrastructure -c PostgresDBContext -o Migrations/Postgres
- Update-Database -Context PostgresDBContext

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Dotnet Core Clean Architecture

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Spedification Pattern
https://medium.com/@michaelmaurice410/implementing-the-specification-pattern-in-c-with-entity-framework-core-bac5d8522480

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Unit of Work
https://steven-giesel.com/blogPost/ae55581a-9722-4735-8d0e-bfcfe4f6ad5a
https://www.infoworld.com/article/2338265/how-to-use-the-unit-of-work-pattern-in-aspnet-core.html
https://code-maze.com/csharp-unit-of-work-pattern/

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Loggin - Serialog
https://www.linkedin.com/pulse/mastering-advanced-logging-net-8-serilog-guide-avadhesh-sengar-lad3c/
https://medium.com/codenx/exploring-serilog-sinks-in-net-8-987e0c3dd686
https://discuss.elastic.co/t/unable-to-send-logs-to-elasticsearch-from-net-8-using-serilog-when-security-is-enabled/356263
https://medium.com/@judevajira/enhance-net-performance-with-structured-logging-using-loggermessageattribute-d48a2a569590

https://blog.datalust.co/dotnet-tracing-with-serilog/
https://github.com/serilog-tracing/serilog-tracing#adding-instrumentation-for-aspnet-core
https://nblumhardt.com/2024/01/serilog-tracing/
https://help.sumologic.com/docs/apm/traces/get-started-transaction-tracing/opentelemetry-instrumentation/net/traceid-spanid-injection-into-logs/
https://github.dev/hgmauri/elasticsearch-with-nest/blob/aa755308ee754bc06e3e047206019d3be72ba6f0/src/Sample.Elasticsearch.WebApi.Core/Extensions/ApiConfigurationExtensions.cs#L25#L42

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Error handling
https://medium.com/@malarsharmila/leveraging-iexceptionhandler-for-effective-error-handling-in-asp-net-core-8-0-5e994ed4e9b4

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Atuhentication - Identity
https://medium.com/@mohamed.ebrahim.mohsen/net8-identity-register-login-email-confirmation-and-two-factor-authentication-2fa-c8acfbc3e14c
https://www.youtube.com/watch?v=scILXOkOn5E

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Filter - Paging - Sorting
https://code-maze.com/searching-aspnet-core-webapi/
https://code-maze.com/filtering-aspnet-core-webapi/
https://code-maze.com/sorting-aspnet-core-webapi/
https://code-maze.com/data-shaping-aspnet-core-webapi/

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Event Driver
https://medium.com/@leonardomartins_27620/event-driven-microservices-with-net-core-and-rabbitmq-205a5555c815

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Kafka
https://medium.com/@siva.veeravarapu/zookeeper-in-net-microservice-architecture-120d2d7ed562
https://medium.com/@siva.veeravarapu/integrating-kafka-with-net-for-pub-sub-messaging-342cb55ac6b2
https://guiferreira.me/archive/2023/a-better-way-to-kafka-event-driven-applications-with-csharp/
https://medium.com/simform-engineering/creating-microservices-with-net-core-and-kafka-a-step-by-step-approach-1737410ba76a
https://blog.stackademic.com/apache-kafka-in-net-7-afd16bfb56eb
https://code-maze.com/aspnetcore-using-kafka-in-a-web-api/
https://medium.com/@ZaradarTR/multi-cluster-kafka-with-strimzi-io-fafd36c2b413
https://docs.ksqldb.io/en/latest/operate-and-deploy/installation/installing/

https://github.com/confluentinc/ksql/blob/master/docker-compose.yml
https://developer.confluent.io/tutorials/generate-streams-of-test-data/ksql.html
https://github.com/confluentinc/demo-scene/blob/master/introduction-to-ksqldb/docker-compose.yml
https://github.com/confluentinc/examples/
https://github.com/confluentinc/cp-demo/blob/7.5.1-post/docker-compose.yml
https://developer.confluent.io/get-started/dotnet/#build-producer

- Define the services for your ksqlDB application

For a local installation, include one or more Kafka brokers in the stack and one or more ksqlDB Server instances.

1 - ZooKeeper: one instance, for cluster metadata
2 - Kafka: one or more instances
3 - Schema Registry: optional, but required for Avro, Protobuf, and JSON_SR
4 - ksqlDB Server: one or more instances
5 - ksqlDB CLI: optional
6 - Other services: like Elasticsearch, optional

https://medium.com/@siva.veeravarapu/rabbitmq-vs-kafka-a-detailed-comparison-with-c-code-snippets-038d6baf8c1a

https://www.c-sharpcorner.com/article/kafka-for-mere-mortals-running-multiple-brokers/
https://ruan.dev/blog/2023/05/17/running-a-multi-broker-kafka-cluster-on-docker

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Cache - Redis
https://blog.stackademic.com/caching-in-net-core-using-redis-a5308c7064b3
https://medium.com/@speedcodelabs/boosting-performance-in-net-core-applications-with-redis-caching-c03c1f97e513
https://medium.com/@siva.veeravarapu/enhancing-net-core-performance-caching-lazy-loading-indexing-and-profiling-e7d1bf509f90

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Cancelation Token
https://medium.com/@shahrukhkhan_7802/understanding-query-cancellation-in-sql-and-asp-net-core-f3dff35be305

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Decorators
https://medium.com/@shahrukhkhan_7802/the-decorator-pattern-a-deep-dive-for-c-developers-d2f631202940

--------------------------------------------------------------------------------------------------------------------------------------------------------
### MediatR Pipeline Logging & Validation
https://code-maze.com/cqrs-mediatr-in-aspnet-core/
https://www.hosting.work/cqrs-mediatr-aspnet-core/
https://code-corner.dev/2020/11/07/Transaction-Management-With-Mediator-Pipelines-in-ASP-NET-Core/
https://goatreview.com/mediatr-quickly-test-handlers-with-unit-tests/
https://codewithmukesh.com/blog/cqrs-and-mediatr-in-aspnet-core/
https://enlear.academy/repository-pattern-and-unit-of-work-with-asp-net-core-web-api-6802e1aa4f78
https://arturkrajewski.silvrback.com/chain-of-responsibility-pattern-for-handling-cross-cutting-concerns
https://www.youtube.com/watch?v=sSIg3fpflI0
https://codewithmukesh.com/blog/validation-with-mediatr-pipeline-behavior-and-fluentvalidation/
https://code-maze.com/cqrs-mediatr-fluentvalidation/
https://radekmaziarka.pl/2018/01/04/mediatr-autofac-shared-transaction-on-command-level/

https://www.reddit.com/r/csharp/comments/svem90/mediatr_registered_with_autofac_can_only_find/
https://tech.playgokids.com/cqrs-with-mediatr-and-autofac-net6/
https://massimomannoni.medium.com/code-cqrs-pattern-for-web-api-cbe61a199c67
https://github.com/alsami/MediatR.Extensions.Autofac.DependencyInjection

--------------------------------------------------------------------------------------------------------------------------------------------------------
### ETL
https://www.youtube.com/watch?v=QuzQLu30TcY
https://www.etlbox.net/
https://dev.to/andreaslennartz/redefining-etl-data-flows-powered-by-c-part-i-1dbg
https://envobi.com/
https://medium.com/swlh/parallel-etl-in-c-3394342e6e64

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Fluent Validation
https://medium.com/codenx/mastering-validation-a-deep-dive-into-fluentvalidation-for-net-8-applications-dc046cf88f03

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Database Seeding

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Response Wrappers

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Healthchecks

--------------------------------------------------------------------------------------------------------------------------------------------------------
### API Versioning

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Localization (fa / en)

--------------------------------------------------------------------------------------------------------------------------------------------------------
### User Auditing

--------------------------------------------------------------------------------------------------------------------------------------------------------
### TestProjects

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Server sent event
https://steven-giesel.com/blogPost/ae55581a-9722-4735-8d0e-bfcfe4f6ad5a
https://www.svix.com/resources/faq/websocket-vs-sse/
https://medium.com/@kova98/server-sent-events-in-net-7f700b21cdb7
https://www.codemag.com/Article/2309051/Developing-Real-Time-Web-Applications-with-Server-Sent-Events-in-ASP.NET-7-Core
https://chrlschn.dev/blog/2023/09/server-sent-events-using-dotnet-7-web-api/
https://dev.to/masanori_msl/aspnet-core-try-server-sent-events-5db2
https://github.com/tpeczek/Lib.AspNetCore.ServerSentEvents
https://www.jetbrains.com/guide/dotnet/tutorials/htmx-aspnetcore/server-sent-events/
https://dreamsof.dev/2024-02-10-server-sent-events-in-asp-net-core-8-react/

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Test
https://medium.com/@kova98/parameterized-unit-tests-in-net-7-with-xunit-183f7bf6a4d7
https://medium.com/@kova98/testing-database-integrations-in-net-with-xunit-b2cea2cb4bc2

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Webhooks
https://medium.com/@kova98/webhooks-in-net-e79530f0d764

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Websocket
https://medium.com/@kova98/websockets-in-net-59f1fc69bdcb

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Storage
https://enlear.academy/microsoft-azure-blob-storage-asp-net-core-mvc-with-identity-ui-6c701861f87c

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Docker
https://medium.com/@craftingcode/dockerizing-asp-net-core-applications-a-comprehensive-guide-4689bc3220f1

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Security
https://github.com/PacktPublishing/Modern-Web-Development-with-ASP.NET-Core-3-Second-Edition/blob/master/README.md

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Kibana
https://medium.com/@siva.veeravarapu/integrating-kibana-logging-in-a-net-application-bc63a4cde08d
https://medium.com/@siva.veeravarapu/centralized-logging-with-elk-stack-elasticsearch-logstash-kibana-in-net-microservices-08c07ad6cab3
https://medium.com/@rewal34/building-logging-in-asp-net-and-visualizing-it-with-elasticsearch-kibana-c17cf79860ff

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Circuit Break
https://medium.com/@siva.veeravarapu/circuit-breaker-in-microservice-architecture-d2db5467f7f1

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Proxy
https://medium.com/@siva.veeravarapu/implementing-the-proxy-pattern-in-c-f4eb94912fc0

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Content Negociation
https://medium.com/@jaimin_99136/custom-formatter-with-content-negotiation-in-net-core-web-api-d8930adc078c

--------------------------------------------------------------------------------------------------------------------------------------------------------
### JWT
https://medium.com/@murataslan1/applying-jwt-access-tokens-and-refresh-tokens-in-asp-net-core-web-api-fc757c9191b9

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Autofac
https://github.com/autofac/Autofac.Extras.FakeItEasy
https://github.com/autofac/Autofac.AspNetCore.Multitenant
https://github.com/autofac/Autofac.Extras.AggregateService
https://github.com/autofac/Autofac.SignalR
https://github.com/autofac/Autofac.ServiceFabric
https://github.com/autofac/Autofac.Pooling
https://www.mattburkedev.com/why-autofac/

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Audit
https://medium.com/the-tech-collective/part-1-using-interceptors-with-entity-framework-core-c377f7ce7223
https://medium.com/the-tech-collective/part-2-using-interceptors-with-entity-framework-core-805aca49585a
https://medium.com/the-tech-collective/part-3-using-interceptors-with-entity-framework-core-0475f49c8947

--------------------------------------------------------------------------------------------------------------------------------------------------------
### RabbitMQ
https://medium.com/@speedcodelabs/understanding-mediatr-and-rabbitmq-key-differences-and-use-cases-f99b7dbbb507

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Interceptors
https://medium.com/@siva.veeravarapu/understanding-interceptors-in-net-4574e2f67cab

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Load Balance
https://medium.com/@siva.veeravarapu/load-balancer-in-net-microservice-architecture-02999ad47062

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Jaeger
https://medium.com/@siva.veeravarapu/distributed-tracing-with-jaeger-ui-in-net-microservices-88c03d878d8e

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Route Groups
https://www.youtube.com/watch?v=CiJVMYuPJ3I

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Secrets
https://www.youtube.com/watch?v=0SkkEUmcC5s

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Distributed Transactions Patterns
https://medium.com/codenx/microservice-architecture-distributed-transactions-patterns-1-90ff8bbcb3e5

--------------------------------------------------------------------------------------------------------------------------------------------------------
### Integration Testing using Testcontainers
https://medium.com/codenx/integration-testing-using-testcontainers-in-net-8-520e8911d081

--------------------------------------------------------------------------------------------------------------------------------------------------------

1. MediatR
2. Polly
3. EF Core
4. Refit
5. Testcontainers
6. MassTransit
7. Marten
8. xUnit
9. Dapper
10. Stryker-Mutator
11. API Gateway

C# .NET 8 — SQL Bulk Insert: Dapper vs BulkCopy vs Table-Value Parameters
C# .NET 8 — Stream Request and Pipeline With MediatR
C# .NET 8 — Unit Of Work Pattern with MediatR Pipeline

https://www.milanjovanovic.tech/blog/fast-document-database-in-net-with-marten/?utm_source=LinkedIn&utm_medium=social&utm_campaign=10.06.2024

https://www.youtube.com/watch?v=uw24-9oi5Ek
https://www.youtube.com/watch?v=xhZU9uX_iTY
https://www.youtube.com/watch?v=I2GMf_QmZEw
https://www.youtube.com/watch?v=7gupK06T68k
https://www.youtube.com/watch?v=Wyfl2zA9r7Y
https://www.youtube.com/watch?v=ohFtQIPqGSo
https://www.youtube.com/watch?v=BU3ySldZVjw
https://www.youtube.com/watch?v=EwWMUUe_9PI
https://www.youtube.com/watch?v=9HKgOxjVcis
https://www.youtube.com/watch?v=z7GCiVTlv04
https://www.youtube.com/watch?v=7rZyI7kPZMI
https://www.youtube.com/watch?v=8P0vKLHbtMg
https://www.youtube.com/watch?v=OkOX9vgozmU
https://www.youtube.com/watch?v=2SvQIJTpMoQ
https://www.youtube.com/watch?v=szvcnQp8QaM
https://www.youtube.com/watch?v=EzeDqRhM09w
https://www.youtube.com/watch?v=3Erte6y2U3s
https://www.youtube.com/watch?v=qjlVAsvQLM8
https://www.youtube.com/watch?v=Fkj6-LN6WKI
https://www.youtube.com/watch?v=_6C-63iqCrw
https://www.youtube.com/watch?v=27GX0ifCLaw
https://www.youtube.com/watch?v=kON9fn01rUQ
https://www.youtube.com/watch?v=qkve9v-gUzA
https://www.youtube.com/watch?v=UjDRcVJB-78
https://www.youtube.com/watch?v=tCOBNCgaZsg

https://www.youtube.com/watch?v=hl2VEfEiINM
https://www.youtube.com/watch?v=nOB-1bnQscU

Entity Framework Extensions
https://learn.microsoft.com/en-us/ef/core/extensions/
https://github.com/borisdj/EFCore.BulkExtensions

- sealed
- ConfigureAwait
- Disposible
- Kestrel: https://medium.com/@siva.veeravarapu/kestrel-server-in-asp-net-core-cbba6911805b
- Solid https://medium.com/@shubhadeepchat/solid-principle-simplified-b18b73b3e440


https://medium.com/@siva.veeravarapu/inserting-bulk-insert-data-from-csv-to-ms-sql-server-using-powershell-a-step-by-step-guide-c8be053dfaf0