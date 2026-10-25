# Shelf — Desktop App (C# / WinForms)

The desktop version of the app from our UCD presentation (Anas Hossam · Youssef Hussein · Hozyfa Batisha).
It implements the three user stories, the v2 wireframes, and the heuristic / accessibility fixes from the slides.

## Run it

Needs the .NET 9 SDK on Windows.

```bash
dotnet run --project ShelfApp
```

Run the tests (each test maps to an acceptance criterion):

```bash
dotnet test
```

## What's implemented

| From the presentation | Where in the app |
|---|---|
| **Story 1 – Compare prices (local first)** | Search → *View details* → *Compare all prices*. Local sellers first sorted by price; overseas sellers labelled "Overseas" with price + shipping. |
| Story 1 AC3 – network error | "Couldn't reach sellers. Check connection or try again." + **Retry** (turn on *Offline mode* in Profile to demo it). |
| **Story 2 – Synced progress** | *Continue Reading* / *Log progress* saves the page; "● Synced 2 min ago" indicator on Home, Library and Profile. Offline → "saved on this PC, will sync when online", syncs when back online. |
| **Story 3 – Drop-risk warning** | Book Details shows Low / Medium / High + one-line reason. Fewer than 5 finished/dropped books → "Not enough history yet". High risk → confirmation **[Cancel] [Add anyway]**. |
| User flow error paths | No results → message + **Retry** / **Browse all books**. Seller link fails → "Couldn't open seller. Copy link?" (Seller E on *Crime and Punishment* has no link, to show this). |
| Heuristic #1 – visibility of status | Progress bar + percentage, sync indicator. |
| Heuristic #5 – error prevention | One **Sign Out** (Profile only) with confirmation; *Remove* asks first; Enter/Esc default to Cancel. |
| Heuristic #6 – recognition over recall | Nav has icon **and** text; theme toggle says "Theme: Dark / Light". |
| Accessibility checklist | Drop risk = icon + text + reason (not colour only), 48 px buttons, labelled search box, screen-reader names, keyboard Tab order, dark + light theme. |
| Onboarding (3 screens) | Shown on first launch and after Sign Out. |

## How to test

### 1. Automated tests (business rules)

```bash
dotnet test
```

All 15 tests in `ShelfApp.Tests/StoryTests.cs` should pass. They cover price sorting (Story 1), drop risk (Story 3), search and the reading streak.

### 2. Manual test checklist (UI)

**Before you start:** to see onboarding and the sample data again, close the app and delete the folder `%AppData%\Shelf`.

Run the app with `dotnet run --project ShelfApp`, then tick each item:

**Onboarding**
- [ ] First launch shows 3 screens: *Get Started* → *Continue* → *Finish Setup*, with "Step X of 3".
- [ ] The last screen has an *Enable sync* checkbox. *Finish Setup* opens Home.

**Home (Home v2)**
- [ ] "Continue reading" card shows *If There's No Tomorrow*, a progress bar, "68% · Page 248 of 367" and "● Synced just now".
- [ ] *Continue Reading* opens "Which page are you on?". Saving a new page updates the bar and percentage.
- [ ] 3 recommendations with risk badges (Crime and Punishment = High Risk).
- [ ] *Theme: Dark* switches to light theme and the label changes to *Theme: Light*.
- [ ] Bottom nav shows icon **and** text; the current tab is bold.

**Story 1 – Compare prices**
- [ ] Search "crime" (press Enter or *Search*) → Crime and Punishment appears with "From EGP 210 · Local".
- [ ] Searching by author ("orwell") and ISBN ("9780140449136") also works.
- [ ] *View details* → *Compare all prices*: Local sellers A (210), B (235), C (260) first, then an "Overseas sellers" section.
- [ ] Overseas cards show price + shipping and the total.
- [ ] Search "ulysses" → *Compare all prices*: "No local seller has this book…" and only overseas sellers.
- [ ] *Select* on a local seller opens the browser.
- [ ] *Select* on Seller E (Crime and Punishment) shows "Couldn't open seller. Copy link?" with *Copy link* / *Dismiss*.

**Error paths**
- [ ] Search "zzz" → "No results for "zzz"…" with *Retry* and *Browse all books* (no dead end).
- [ ] Profile → tick *Offline mode*. Search anything → "Couldn't reach sellers. Check connection or try again." with *Retry*.
- [ ] While offline, Book Details shows the same error in the price card.

**Story 2 – Progress & sync**
- [ ] Offline mode on: log progress in Library → status says "Offline · saved on this PC, will sync when online".
- [ ] Turn offline mode off → status changes to "● Synced just now".
- [ ] Close and reopen the app → progress is still there.

**Story 3 – Drop risk**
- [ ] Crime and Punishment details: red card with warning icon, "DROP RISK: HIGH" and "You dropped 3 of 4 long (400+ page) books. Consider a shorter novel."
- [ ] *Dismiss* hides the warning.
- [ ] *Add to library* on a high-risk book asks "This book has a high drop risk for you. Add anyway?" with *Cancel* / *Add anyway*.
- [ ] *Cancel* doesn't add it; *Add anyway* adds it and the button becomes "✓ In your library".
- [ ] A short book (The Little Prince) shows "DROP RISK: LOW" and adds without a question.
- [ ] Remove books from the Library until fewer than 5 are finished/dropped → details say "Not enough history yet — add more books to see drop risk."

**Library**
- [ ] Books are grouped into Reading / Finished / Dropped.
- [ ] *Mark finished*, *Drop* and *Resume* move the book to the right group.
- [ ] *Remove* asks for confirmation first.

**Profile (Profile v2)**
- [ ] Stats say "books", "pages", "hours", "days in a row" (correct grammar).
- [ ] Reading history shows the latest 5 books with %.
- [ ] There is only **one** *Sign Out* in the app. It asks for confirmation; *Cancel* stays, *Sign Out* goes back to onboarding and the library is kept.

**Accessibility**
- [ ] The whole app can be used with Tab / Shift+Tab / Enter / Space (no mouse).
- [ ] In dialogs, Enter and Esc choose the safe option (*Cancel*).
- [ ] Drop risk is never shown by colour alone (always icon + text).
- [ ] Optional: turn on Windows Narrator (Ctrl+Win+Enter) and check the nav reads "Home, selected", "Search"…

## Project structure

```
ShelfApp/
  Models/      Book, Offer, UserData, LibraryEntry
  Services/    BookCatalog (sample data), BookService (search + offers),
               DropRiskCalculator, ReadingStats, DataStore (JSON save/load)
  UI/          MainForm (navigation), Theme, Ui (shared controls), Dialogs
  UI/Views/    Onboarding, Home, Search, BookDetail, Offers, Library, Profile
ShelfApp.Tests/  xUnit tests for the business rules
```

## Simplifications (on purpose, for a student project)

- **Sellers are sample data**, not real bookstore APIs. Prices are in EGP and seller names are "Seller A–E" like in the wireframes.
- **Sync is local.** Data is saved to `%AppData%\Shelf\shelf-data.json`. There is no server, so the multi-device rules (last-write-wins merge) are not implemented — the indicator shows when the data was last saved while online.
- **Drop-risk rule is simple:** it compares the book with your finished/dropped books of a similar length (400+ pages = long). High ≥ 60 % dropped, Medium ≥ 30 %.
- **No real accounts.** Sign Out returns to onboarding; your library stays on the PC.
- The first launch loads sample history for our persona **Layla Hassan**, so the drop-risk warning has data to work with.
