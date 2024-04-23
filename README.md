All'interno di questo repository è presente il backup del database SQLServer (Utenti.bacpac). 
Per ripristinarlo seguire il tutorial presente in questo [link](https://www.c-sharpcorner.com/article/how-to-import-or-restore-bacpac-file-from-ssms/).

Per avviare il progetto, e' sufficiente aprirlo con Visual Studio e selezionare come progetto di avvio "Unicam.Progetto4.Web". 
Si aprira' automaticamente l'interfaccia di Swagger.

La Web API permette di:

- creare un UTENTE senza validazione
  - visualizzare una lista utenti, senza validazione, digitando il nome utente o parte di esso. se si cancella il campo "name" verrà restituita la lista completa degli utenti
  - visualizzare un utente, senza validazione, digitando un numero corrispondente ad un ID

Per sfruttare le prossime opzioni bisogna creare prima un token e poi cliccare il pulsante in alto a destra "Authorize". 
Nella finestra che si apre, nel campo "Value" digitare prima "Bearer" e poi il Token

- creare una RISORSA
  - visualizzare una lista risorse digitando il nome risorsa o parte di esso. se si cancella il campo "name" verrà restituita la lista completa delle risorse
  - visualizzare una risorsa digitando un numero corrispondente ad un ID
  - ricercare la disponibilità di una risorsa digitando l'ID della risorsa, la data di inizio e la data di fine. Se si cancella il campo "idRisorsa" verranno visualizzate tutte le risorse disponibili per quelle date

- creare una PRENOTAZIONE
  - visualizzare una lista prenotazioni digitando l'ID della risorsa. se si cancella il campo "id" verrà restituita la lista completa delle prenotazioni

Progetto realizzato da:
Marco Torquati (matricola 119127)



