using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.DeleteContact;

public class DeleteContactNotificationHandler : INotificationHandler<DeleteContactNotification>
{
    private readonly ILogger<DeleteContactNotificationHandler> _logger;

    public DeleteContactNotificationHandler(ILogger<DeleteContactNotificationHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DeleteContactNotification notification, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Contact with ID {notification.Id} has been deleted.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error while handling DeleteContactNotification: {ex.Message}");
        }

        return Task.CompletedTask;
    }
}
