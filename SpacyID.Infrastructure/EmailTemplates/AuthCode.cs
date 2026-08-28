namespace SpacyID.Infrastructure.EmailTemplates;

internal static class EmailTemplate
{
    public static string GetTemplateEmailWithCode(string code)
    {
        return $@"
<html>
<head>
    <style>
        /* Адаптивные стили для мобильных экранов */
        @media only screen and (max-width: 480px) {{
            .auth-code {{
                font-size: 24px !important;
                letter-spacing: 4px !important;
            }}
        }}
    </style>
</head>
<body style='margin: 0; padding: 0; background-color: #0b0f19;'>
    <div style='background-color: #0b0f19; padding: 40px 20px; font-family: -apple-system, BlinkMacSystemFont, ""Segoe UI"", Roboto, Helvetica, Arial, sans-serif;'>
        <table align='center' width='100%' border='0' cellpadding='0' cellspacing='0' style='max-width: 480px; background-color: #161b26; border: 1px solid #242b3d; border-radius: 16px; overflow: hidden; box-shadow: 0 10px 25px rgba(0,0,0,0.3);'>
            
            <!-- Шапка с названием системы -->
            <tr>
                <td style='padding: 32px 24px 16px 24px; text-align: center;'>
                    <h1 style='color: #4f46e5; margin: 0; font-size: 28px; font-weight: 800; letter-spacing: -0.5px;'>
                        Spacy<span style='color: #ffffff;'>ID</span>
                    </h1>
                </td>
            </tr>

            <!-- Основной контент -->
            <tr>
                <td style='padding: 0 32px; text-align: center; color: #9ca3af;'>
                    <p style='font-size: 16px; line-height: 1.5; margin: 0 0 24px 0;'>
                        Используйте этот одноразовый код для подтверждения входа в вашу учетную запись.
                    </p>
                    
                    <!-- Блок с кодом авторизации -->
                    <table align='center' border='0' cellpadding='0' cellspacing='0' style='margin: 0 auto 24px auto;'>
                        <tr>
                            <td align='center' style='background-color: #1f293d; border: 1px solid #374151; border-radius: 12px; padding: 16px 32px;'>
                                <span class='auth-code' style='color: #38bdf8; font-family: ""Courier New"", Courier, monospace; font-size: 32px; font-weight: bold; letter-spacing: 6px; display: inline-block;'>
                                    {code}
                                </span>
                            </td>
                        </tr>
                    </table>

                    <p style='font-size: 13px; color: #6b7280; line-height: 1.5; margin: 0 0 32px 0;'>
                        Код действителен в течение ограниченного времени. Если вы не запрашивали этот код, просто проигнорируйте это письмо.
                    </p>
                </td>
            </tr>

            <!-- Подвал -->
            <tr>
                <td style='background-color: #0f1420; padding: 20px 24px; text-align: center; border-top: 1px solid #242b3d;'>
                    <p style='margin: 0; font-size: 12px; color: #4b5563;'>
                        © {DateTime.Now.Year} SpacyID. Безопасная аутентификация.
                    </p>
                </td>
            </tr>

        </table>
    </div>
</body>
</html>";
    }
}
