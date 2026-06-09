/**
 * Gmail relay for Premier Property Hub (Render free tier blocks SMTP ports).
 *
 * Deploy:
 * 1. Open https://script.google.com → New project
 * 2. Paste this file, save
 * 3. Deploy → New deployment → Web app
 *    - Execute as: Me
 *    - Who has access: Anyone
 * 4. Copy the Web app URL into appsettings.json → Email:GmailRelayUrl
 * 5. Set GmailRelaySecret to the same value used below
 */
const RELAY_SECRET = 'premier-hub-2026';

function doPost(e) {
  try {
    const data = JSON.parse(e.postData.contents);
    if (data.secret !== RELAY_SECRET) {
      return json({ success: false, message: 'Unauthorized' });
    }

    const options = {
      htmlBody: data.htmlBody,
      name: data.fromName || 'Premier Property Hub',
    };

    if (data.attachments && data.attachments.length) {
      options.attachments = data.attachments.map(function (attachment) {
        return Utilities.newBlob(
          Utilities.base64Decode(attachment.content),
          attachment.contentType,
          attachment.filename
        );
      });
    }

    GmailApp.sendEmail(data.to, data.subject, '', options);
    return json({ success: true });
  } catch (error) {
    return json({ success: false, message: String(error) });
  }
}

function json(payload) {
  return ContentService.createTextOutput(JSON.stringify(payload)).setMimeType(
    ContentService.MimeType.JSON
  );
}
