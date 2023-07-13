using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.CreateContact;

public class CreateContactNotificationHandler : INotificationHandler<CreateContactNotification>
{
    private readonly ILogger<CreateContactNotificationHandler> _logger;

    public CreateContactNotificationHandler(ILogger<CreateContactNotificationHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CreateContactNotification notification, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Contact with ID {notification.Id} has been created.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error while handling CreateContactNotification: {ex.Message}");
        }

        return Task.CompletedTask;
    }
}
