
Markdown

# PostgresConnectAxum

**PostgresConnectAxum** is een C# Windows Forms-toepassing (.NET) ontworpen voor het beheren, maken van back-ups, herstellen en uitlezen van configuratie- en databasedata van een **Axum** digitaal audiomengpaneel / netwerksysteem (Linux-gebaseerde controller node).

De applicatie maakt gebruik van **SSH** en **PostgreSQL (Npgsql)** om op afstand beheer- en onderhoudstaken uit te voeren op het Axum-systeem.

---

## 📸 Functionaliteiten

- **Remote SSH Beheer (`Renci.SshNet`)**:
  - **Automated Service Management**: Het gecontroleerd stoppen en starten van Axum-systeemdiensten (`axum-engine`, `axum-gateway`, `axum-address`, `axum-learner`, `axum-cleandb`, `lighttpd`, `xinetd`).
  - **Back-up genereren**: Het aanmaken van database dumps (`pg_dumpall`) en het opslaan van systeembestanden (`/var/lib/axum/.backup`).
  - **Systeemherstel & Reboot**: Automatisch herstellen van de SQL-database en configuratiebestanden met een aansluitende systeem-reboot.
  - **Logbestand Onderhoud**: Het opschonen van oude logbestanden (`/var/log/*.log*`).

- **Bestandsoverdracht (Upload / Download via PSCP)**:
  - Downloaden van `.backup` en `dbaxumall.sql` naar een lokale map op de PC.
  - Uploaden van lokale back-upbestanden rechtstreeks naar het Axum-systeem.

- **Directe PostgreSQL Database Inzage (`Npgsql`)**:
  - Rechtstreekse SQL-verbinding met de PostgreSQL database op poort 5432.
  - Direct uitlezen en weergave van tabellen in een `DataGridView`, waaronder:
    - `addresses` (IP-/netwerkadressen)
    - `predefined_node_config` (Vooraf ingestelde node-configuraties)

---

## 🛠️ Vereisten & Afhankelijkheden

### Ontwikkelomgeving
- **Framework**: .NET Framework 4.7.2+ of .NET 6.0/8.0 Windows Desktop Runtime
- **IDE**: Visual Studio 2019 / 2022

### NuGet Packages
- **[Npgsql](https://www.nuget.org/packages/Npgsql/)**: Voor de PostgreSQL databaseverbinding.
- **[SSH.NET](https://www.nuget.org/packages/SSH.NET/) (`Renci.SshNet`)**: Voor het uitvoeren van SSH-commando's op het Linux-systeem.

### Externe Tools
- **`pscp.exe`** (PuTTY Secure Copy Client): Zorg ervoor dat `pscp` aanwezig is in het Windows PATH of de uitvoeringsmap van de applicatie voor de bestandsoverdracht via SCP/SFTP.

---

## 📋 Standaard Inlog- & Netwerkgegevens

De applicatie maakt standaard gebruik van de volgende systeeminstellingen (aanpasbaar in de broncode):

| Parameter | Standaardwaarde |
| :--- | :--- |
| **SSH Gebruiker** | `root` |
| **SSH Wachtwoord** | `axum` |
| **PostgreSQL Database** | `axum` |
| **PostgreSQL Gebruiker** | `axum` / `postgres` |
| **PostgreSQL Wachtwoord**| `axum` |
| **PostgreSQL Poort** | `5432` |

---

## 🚀 Gebruiksaanwijzing

1. **Verbinden**:
   - Vul het IP-adres van het Axum-systeem in (of kies uit de ComboBox) en klik op **Connect**.
2. **Back-up Maken**:
   - Klik op de back-upknop om de actieve services stop te zetten, een database-dump te maken en de configuratie op te slaan.
3. **Instellingen Downloaden / Uploaden**:
   - Selecteer een lokale doelmap om de bestanden `.backup` en `dbaxumall.sql` op te halen of te uploaden via PSCP.
4. **Data Inzien**:
   - Klik op de gewenste knop (bijv. *View Addresses* of *Node Config*) om de live gegevens in de DataGridView te laden.
5. **Herstellen**:
   - Voer een restore uit om de `dbaxumall.sql` terug te zetten in PostgreSQL waarna het Axum-systeem herstart.

---

## 📄 Licentie

Dit project is gelicenseerd onder de MIT-licentie. Zie het `LICENSE` bestand voor meer informatie.


Gemini is AI en kan fouten maken, ook over mensen. Jouw privacy en GeminiOpent in een nieuw venster
Analyseren

# PostgresConnectAxum

**PostgresConnectAxum** is een C# Windows Forms-toepassing (.NET) ontworpen voor het beheren, maken van back-ups, herstellen en uitlezen van configuratie- en databasedata van een **Axum** digitaal audiomengpaneel / netwerksysteem (Linux-gebaseerde controller node).

De applicatie maakt gebruik van **SSH** en **PostgreSQL (Npgsql)** om op afstand beheer- en onderhoudstaken uit te voeren op het Axum-systeem.

---

## 📸 Functionaliteiten

- **Remote SSH Beheer (`Renci.SshNet`)**:
  - **Automated Service Management**: Het gecontroleerd stoppen en starten van Axum-systeemdiensten (`axum-engine`, `axum-gateway`, `axum-address`, `axum-learner`, `axum-cleandb`, `lighttpd`, `xinetd`).
  - **Back-up genereren**: Het aanmaken van database dumps (`pg_dumpall`) en het opslaan van systeembestanden (`/var/lib/axum/.backup`).
  - **Systeemherstel & Reboot**: Automatisch herstellen van de SQL-database en configuratiebestanden met een aansluitende systeem-reboot.
  - **Logbestand Onderhoud**: Het opschonen van oude logbestanden (`/var/log/*.log*`).

- **Bestandsoverdracht (Upload / Download via PSCP)**:
  - Downloaden van `.backup` en `dbaxumall.sql` naar een lokale map op de PC.
  - Uploaden van lokale back-upbestanden rechtstreeks naar het Axum-systeem.

- **Directe PostgreSQL Database Inzage (`Npgsql`)**:
  - Rechtstreekse SQL-verbinding met de PostgreSQL database op poort 5432.
  - Direct uitlezen en weergave van tabellen in een `DataGridView`, waaronder:
    - `addresses` (IP-/netwerkadressen)
    - `predefined_node_config` (Vooraf ingestelde node-configuraties)

---

## 🛠️ Vereisten & Afhankelijkheden

### Ontwikkelomgeving
- **Framework**: .NET Framework 4.7.2+ of .NET 6.0/8.0 Windows Desktop Runtime
- **IDE**: Visual Studio 2019 / 2022

### NuGet Packages
- **[Npgsql](https://www.nuget.org/packages/Npgsql/)**: Voor de PostgreSQL databaseverbinding.
- **[SSH.NET](https://www.nuget.org/packages/SSH.NET/) (`Renci.SshNet`)**: Voor het uitvoeren van SSH-commando's op het Linux-systeem.

### Externe Tools
- **`pscp.exe`** (PuTTY Secure Copy Client): Zorg ervoor dat `pscp` aanwezig is in het Windows PATH of de uitvoeringsmap van de applicatie voor de bestandsoverdracht via SCP/SFTP.

---

## 📋 Standaard Inlog- & Netwerkgegevens

De applicatie maakt standaard gebruik van de volgende systeeminstellingen (aanpasbaar in de broncode):

| Parameter | Standaardwaarde |
| :--- | :--- |
| **SSH Gebruiker** | `root` |
| **SSH Wachtwoord** | `axum` |
| **PostgreSQL Database** | `axum` |
| **PostgreSQL Gebruiker** | `axum` / `postgres` |
| **PostgreSQL Wachtwoord**| `axum` |
| **PostgreSQL Poort** | `5432` |

---

## 🚀 Gebruiksaanwijzing

1. **Verbinden**:
   - Vul het IP-adres van het Axum-systeem in (of kies uit de ComboBox) en klik op **Connect**.
2. **Back-up Maken**:
   - Klik op de back-upknop om de actieve services stop te zetten, een database-dump te maken en de configuratie op te slaan.
3. **Instellingen Downloaden / Uploaden**:
   - Selecteer een lokale doelmap om de bestanden `.backup` en `dbaxumall.sql` op te halen of te uploaden via PSCP.
4. **Data Inzien**:
   - Klik op de gewenste knop (bijv. *View Addresses* of *Node Config*) om de live gegevens in de DataGridView te laden.
5. **Herstellen**:
   - Voer een restore uit om de `dbaxumall.sql` terug te zetten in PostgreSQL waarna het Axum-systeem herstart.

---

## 📄 Licentie

Dit project is gelicenseerd onder de MIT-licentie. Zie het `LICENSE` bestand voor meer informatie.

README.md
README.md weergeven.
