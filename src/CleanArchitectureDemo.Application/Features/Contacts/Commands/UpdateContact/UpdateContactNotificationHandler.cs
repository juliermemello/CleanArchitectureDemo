using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.UpdateContact;

public class UpdateContactNotificationHandler : INotificationHandler<UpdateContactNotification>
{
    private readonly ILogger<UpdateContactNotificationHandler> _logger;

    public UpdateContactNotificationHandler(ILogger<UpdateContactNotificationHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(UpdateContactNotification notification, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Contact with ID {notification.Id} has been updated.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error while handling UpdateContactNotification: {ex.Message}");
        }

        return Task.CompletedTask;
    }
}
