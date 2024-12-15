API built using .NET 8 and following a Vertical Slice Architecture.

It depends on a Redis DB that caches the response object of the GET request ("v1/stocks/{stockTicker}") for 5 minutes.
The idea is to reduce the cost of using the source API for the stock information.

It uses the MediatR package to handle the requests and their respective slices.

To run this project, you need to execute the Docker Compose file to run a Redis DB in a container.
