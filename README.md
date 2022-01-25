# FeedR
**Sample** .NET6 **microservices** solution which acts as the data aggregator for the different feeds.
The **purpose** of this solution is to **explore** the latest framework and **play** with different patterns, tools & libraries that can be useful when building **distributed applications** (but not only).
The overall repository structure consists of the following projects located under `src` directory:

- Gateway - API gateway providing a public facade for the underlying, internal services
- Aggregator - core service responsible for aggregating the data from different feeds
- Notifier - supporting service responsible for sending the notifications
- Feeds
  - News - sample feed providing the worldwide news
  - Quotes - sample feed providing the quotes


<details open="open">
  <summary>TOOLS</summary>
  <ol>
    <li><a href="#Tye">- Tye</a></li>
  </ol>
</details>


## Tye

Tye is a tool that makes developing, testing, and deploying microservices and distributed applications easier. 
Project Tye includes a local orchestrator to make developing microservices easier and the ability to deploy microservices to Kubernetes with minimal configuration.

Documentation and installation: [Tye](<https://github.com/dotnet/tye>).
