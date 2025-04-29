using Application.DTOs;

namespace Application.Services
{
    public class HelpDeskService
    {
        public List<HelpTipDTO> GetHelpTips()
        {
            return new List<HelpTipDTO>
            {
                new HelpTipDTO
                {
                    Title = "Practice Deep Breathing",
                    Description = "Take slow, deep breaths to calm your nervous system when you feel anger rising."
                },
                new HelpTipDTO
                {
                    Title = "Walk Away Temporarily",
                    Description = "Leave the situation if possible to prevent saying or doing something you might regret."
                },
                new HelpTipDTO
                {
                    Title = "Use Relaxation Techniques",
                    Description = "Practice mindfulness, meditation, or listen to calming music."
                },
                new HelpTipDTO
                {
                    Title = "Keep a Mood Journal",
                    Description = "Track your feelings daily to recognize anger patterns and triggers."
                },
                new HelpTipDTO
                {
                    Title = "Exercise Regularly",
                    Description = "Physical activity can help reduce stress that can cause anger."
                },
                new HelpTipDTO
                {
                    Title = "Seek Professional Help",
                    Description = "Therapists can help you understand and manage your anger more effectively."
                }
            };
        }
    }
}
