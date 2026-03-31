Based on the submission guide requirements, your privacy policy must cover these points. Here's a ready-to-use draft tailored to Bindery MCP's actual behavior:

Privacy Policy — Bindery MCP

Last updated: March 31, 2026

What Bindery MCP does
Bindery MCP is a local MCP server that provides book authoring tools (chapter navigation, full-text search, typography formatting, translation management, and version snapshots) for AI assistants like Claude Desktop.

Data collection
Bindery MCP does not collect, transmit, or store any personal data. All operations run entirely on your local machine.

File access
The extension reads and writes files only within the book project directories you explicitly configure via the "Books" setting. Write operations are limited to:

.bindery/ folder (search index, translations.json)
Story, Notes, and Arc folders (typography formatting, git snapshots)
Network connections
Bindery MCP makes no network requests by default. If you optionally configure an Ollama URL, embedding requests are sent to that local instance only. No data is sent to any external or third-party server.

Third-party sharing
No data is shared with third parties.

Data retention
No data is retained outside your local filesystem.

Analytics and telemetry
Bindery MCP does not include any analytics, telemetry, or tracking.

Changes to this policy
Updates will be posted on this page with a revised date.

Contact
For privacy questions: [your email or GitHub Issues link]
GitHub: https://github.com/evdboom/bindery

The required elements per the guide are: what data is collected, how it's used/stored, third-party sharing, retention, and contact info. Since Bindery is purely local, this is straightforward — the key message is "we collect nothing."