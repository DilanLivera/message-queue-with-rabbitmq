## Message queue with RabbitMQ

A simple implementation of a message queue using RabbitMQ with a Producer and a Consumer

How to

1. Pull RabbitMQ docker image - `docker pull rabbitmq:3-management`
2. Run the image - `docker run -d -p 15672:15672 -p 5672:5672 --name test-rabbit rabbitmq:3-management`
3. To stop the image - `docker stop test-rabbit`
4. To start the image - `docker start test-rabbit`

### Links
- https://www.twitch.tv/videos/786565776
- https://medium.com/dev-genius/rabbitmq-with-docker-on-windows-in-30-minutes-172e88bb0808
- https://hub.docker.com/_/rabbitmq
- https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html
- https://www.rabbitmq.com/dotnet-api-guide.html