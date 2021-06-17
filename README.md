# Projekat Movie ASP
## Tema projekta - Online bioskop
Projekat je rađen kao online bioskop, gde svaki film ima svoj jedinstveni naziv, kao i link koji vodi do videa filma, takođe ima opis, godinu izdanja i trajanje. Pored toga film može imati više žanrova i više glumaca. Žanrovi i glumci su jedinstveni i ne mogu se ponavljati.
## Funkcionalosti
Funkcionalnosti zavise od uloge korisnika, postoji neautorizovani korinik,autorizovani korisnik i admin. <br/>
**Neautorizovani korisnici** imaju mogućnost pretraživanja filmova, žanrova i glumaca. Kako bi postali autorizovani korisnici moraju se prvo registrovati, potom potvrditi svoju registraciju pomoću aktivacionog koda koji dobiju na svoj mejl kojim su izvršili registraiju i nakon toga se mogu ulogovati.<br/>
**Autorizovani korisnici** takođe imaju mogućnost prikaza i pretrage svim filmova, žanrova i glumaca ali takođe mogu prikazati svoje omiljenje filmove(ukoliko ih ima) i svoje podatke.<br/>
Pored prikaza imaju mogućnost dodavanja filmova u omiljene, ocenjivanje i komentarisanje filmova. Takođe mogu izmeniti svoje podatke, vodeći računa da ne postoji korisnik sa istim korisničkim imenom, kao i obrisati svoj profil.<br/>
**Admin** takođe ima mogućnost prikaza svih filmova, žanrova i glumaca, pored toga može prikazati sve aktivnosti drugih korisnika (prikazaće se aktivnosti svih korisnika nevezano od njihove uloge), kao i informacije o korisnicima koji se nalaze u bazi podataka. Pored prikaza admin ima mogućnost dodavanja, brisanja i izmene podataka svih filmova, glumaca i žanrova, kao i izmene svojih podataka i brisanje svog profila.
## Logovanje
Logovanje se vrši putem username-a i passworda, ulogovati se mogu samo oni korisnici kojima je verification postavljen na true nakon potvrde registracije.
Korisnici se inicijalno unose u bazu kroz fejker (kontroler InsertAll) i svima je verifitacion postavljen na true kako bi se moglo ulogovati sa jednim od naloga.
## Struktura projekta
Projekat je podeljen u zasebne celine i svaka celina ima svoju ulogu.<br/>
**Domain**<br/>
**DataAccess**<br/>
**Application**<br/>
**Implementation**<br/>
**Api**
## Dijagram baze podataka


