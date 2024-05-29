using MediatR;
using System.Net.Mail;

namespace Club.Application.Profiles.CreateProfile;

public record CreateProfileCommand(string Name, MailAddress MailAddress) 
    : IRequest<CreateProfileCommandResponse>;