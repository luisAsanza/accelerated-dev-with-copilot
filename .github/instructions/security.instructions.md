# Security Instructions

Purpose
-------
Provide baseline security expectations for contributors, maintainers, and CI/CD pipelines for this repository.

Scope
-----
Applies to all code, configuration, CI/CD, and data stored or processed by this repository and its services.

Paths
-----
- **Repository root:** `./` (all repository files)
- **All files / glob:** `**/*` (matches every file and directory)
- **Source code:** `src/**`
- **Tests:** `tests/**`
- **CI & config:** `.github/**`, `*.yml`, `*.yaml`, `appSettings.json`, `*.config`
- **Documentation & scripts:** `README.md`, `docs/**`, `scripts/**`
- **Build artifacts / generated:** `bin/**`, `obj/**`

Responsibilities
----------------
- **Maintainers:** enforce policies, approve security-related PRs, and respond to incidents.
- **Contributors:** follow secure coding practices, avoid committing secrets, and address review comments.
- **Everyone:** report vulnerabilities and suspicious activity promptly.

Secure Development Practices
---------------------------
- Follow least-privilege principles for accounts and services.
- Validate inputs and use safe defaults; prefer explicit allow-lists over deny-lists.
- Sanitize and encode data crossing trust boundaries.
- Use established libraries and avoid rolling your own crypto.

Secrets & Credentials
---------------------
- Never commit secrets (API keys, passwords, tokens) to the repo.
- Store secrets in approved secret stores (e.g., Azure Key Vault, GitHub Secrets) and reference them in CI only.
- Rotate compromised or long-lived credentials immediately.

Dependency & Supply Chain Management
-----------------------------------
- Keep dependencies up to date and apply security patches promptly.
- Use automated dependency scanners (dependabot, Snyk, etc.) where available.
- Review transitive dependency changes for risk before merging.

Code Review & Pull Requests
---------------------------
- Require at least one approving review for code changes that affect security, authentication, authorization, or data handling.
- Include security rationale in PR descriptions for changes that affect architecture, credentials, or third-party integrations.

CI/CD Pipeline Security
------------------------
- Ensure CI runners use minimal privileges and are patched regularly.
- Enable secrets scanning and block runs that attempt to expose secrets in logs.
- Sign releases/artifacts where practical.

Access Control
--------------
- Apply role-based access control (RBAC) and grant minimal permissions needed to perform tasks.
- Revoke access promptly when no longer required.

Logging, Monitoring & Incident Response
--------------------------------------
- Log security-relevant events and protect logs from tampering.
- Monitor for anomalous activity and create alerts for critical events.
- Follow an established incident response process; escalate to maintainers and stakeholders as needed.

Vulnerability Reporting
-----------------------
- If you discover a vulnerability, report it confidentially to the maintainers (create a private issue or contact the security lead).
- Include reproduction steps, impact, and suggested mitigations. Do not publish or disclose externally until resolved.

Third-party Services & Data Handling
-----------------------------------
- Evaluate third-party services for security and data protection.
- Classify and handle sensitive data with encryption in transit and at rest.

Automated Scanning & Testing
----------------------------
- Enable static analysis, secret scanning, and dependency vulnerability scanning in CI.
- Add unit and integration tests for security-sensitive behavior where practical.

Training & Awareness
--------------------
- Encourage maintainers and contributors to follow security best practices and periodic training.

Contacts & Escalation
---------------------
- For security issues, contact the repository maintainers or the organization security team.

Notes
-----
This document contains baseline guidance and should be adapted to organizational policies and regulatory requirements where applicable.

