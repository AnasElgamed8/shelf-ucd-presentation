# Wireframe Generation Prompts

Use these prompts with Figma AI, Galileo AI, Uizard, v0.dev, Magic Patterns, or any UI generation tool. Each prompt includes: context, screen spec, component breakdown, accessibility requirements, and style tokens.

---

## Global Context (Prepend to Every Prompt)

```
APP CONTEXT:
- Name: Shelf
- Type: Mobile book price comparison + reading tracker (iOS/Android)
- Core value: Search a book → see local sellers first (sorted by price) → overseas sellers → drop-risk warning based on personal history → synced progress across devices
- Platform: Mobile-first (phone). Dark theme default, light mode supported.
- Brand colours (dark): Background #0D0D0D, Surface #1A1A1A, Surface-elevated #242424, Primary/Accent #E8DCCC (beige), Text-primary #F5F0E8, Text-secondary #A89E90, Error #CC4444, Success #44CC44, Warning #CCAA44
- Typography: System font (San Francisco / Roboto), scale: Display 32/38, Headline 24/32, Title 18/26, Body 16/24, Caption 13/18
- Spacing: 4dp base unit. Touch targets: minimum 48×48dp, comfortable 56×56dp
- Corner radius: 12dp (cards), 8dp (buttons), 24dp (bottom nav)
- Icons: SF Symbols / Material Icons, 24dp default
- Accessibility baseline: WCAG 2.1 AA (4.5:1 text, 3:1 large text/UI), dynamic type support, TalkBack/VoiceOver labels on all interactive elements, no colour-only meaning
```

---

## Screen 1: Search Results (Local First, Then Overseas)

### Prompt for AI Generation

```
Generate a HIGH-FIDELITY mobile screen for "Search Results" in the Shelf app.

SCREEN PURPOSE:
User searched for a book title. Results show LOCAL sellers first (sorted by price ascending), then OVERSEAS sellers. Each seller card shows: seller name, price, delivery estimate, and a primary action to select.

LAYOUT (top to bottom):
1. Navigation bar (64dp): Back chevron (←) + page title "Results: Crime and Punishment" + filter icon (optional, disabled state)
2. Results list (scrollable):
   - Section header: "📍 LOCAL SELLERS (3)" — beige text #E8DCCC, uppercase, tracking 0.5px, 16dp padding horizontal
   - Seller cards (repeat for each local seller):
     * Card: surface #1A1A1A, 12dp radius, 16dp padding, 12dp gap between cards
     * Row 1: Seller name (Body, #F5F0E8) + "Local" badge (Caption, #44CC44 text on #0D2A1A bg, 4dp radius)
     * Row 2: Price large (Headline, #E8DCCC) + delivery estimate (Caption, #A89E90) — e.g., "EGP 210  •  2 days"
     * Row 3: Full-width button "Select" (Primary, 48dp height, 8dp radius, #0D0D0D bg, #E8DCCC text) — OR outlined variant if secondary
   - Divider (1dp, #2A2A2A, 16dp horizontal margin)
   - Section header: "🌍 OVERSEAS SELLERS (2)" — same style
   - Overseas seller cards: same structure, but badge says "Overseas" (Caption, #CCAA44 on #2A1A0D), price includes shipping note
3. Bottom navigation bar (88dp, fixed): Home | Search (active) | Library | Profile — ICON + TEXT LABEL (Caption, #E8DCCC active / #A89E90 inactive)

INTERACTION STATES:
- Seller card: pressed → surface #242424
- Select button: pressed → #E8DCCC bg, #0D0D0D text; disabled → #2A2A2A bg, #5A5550 text
- Bottom nav: active item gets #E8DCCC, inactive #A89E90

ACCESSIBILITY REQUIREMENTS (NON-NEGOTIABLE):
- Every interactive element has accessibilityLabel: "Select Seller A, EGP 210, 2 days delivery"
- Section headers are announced as headings (accessibilityTraits: header)
- Price and delivery are separate accessibility elements or combined logically
- Touch targets ≥ 56×56dp (button height 56dp preferred)
- Contrast: all text ≥ 4.5:1 against background
- Dynamic type: all text scales with system setting (use relative units)
- Focus order: Back → Section headers → Seller cards (top to bottom) → Bottom nav

EMPTY STATE:
If no local results: show "No local sellers found for 'X'" with illustration, then overseas section.
If no results at all: full-screen empty state with "No results. Try different spelling or author." + [Retry] [Browse Categories]

DELIVERABLE:
Figma frame 390×844 (iPhone 14/15), dark mode. Also provide light mode variant (Background #F5F0E8, Surface #FFFFFF, Text-primary #0D0D0D, Primary #8B7D6B).
```

### Component Checklist (for Manual Review)

| Component | Spec | A11y |
|-----------|------|------|
| Back button | 44×44dp hit area, chevron icon + "Back" label | ✅ Label |
| Page title | Headline, #F5F0E8 | ✅ Heading |
| Section header | Caption uppercase, #E8DCCC, 16dp padding | ✅ Header trait |
| Seller card | 12dp radius, #1A1A1A bg, 16dp pad | — |
| Seller name | Body, #F5F0E8 | — |
| Local/Overseas badge | 4dp radius, coloured bg + text | ✅ Included in card label |
| Price | Headline, #E8DCCC | ✅ In card label |
| Delivery | Caption, #A89E90 | ✅ In card label |
| Select button | 56dp h, full width, 8dp radius | ✅ Label + role=button |
| Divider | 1dp #2A2A2A | — |
| Bottom nav | 88dp h, 4 items, icon+label | ✅ Labels, selected state |

---

## Screen 2: Book Detail (with Drop-Risk Warning)

### Prompt for AI Generation

```
Generate a HIGH-FIDELITY mobile screen for "Book Detail" in the Shelf app.

SCREEN PURPOSE:
User tapped a search result. Screen shows book metadata, a prominent DROP-RISK WARNING (core differentiator), best price summary, and primary actions.

LAYOUT (top to bottom):
1. Navigation bar (64dp): Back chevron + "Book Details" title + share icon (optional)
2. Hero section (200dp height, full width):
   - Book cover (120×180dp, 8dp radius, shadow elevation 4)
   - Title (Title, #F5F0E8, max 2 lines, truncate tail)
   - Author (Body, #A89E90)
   - Metadata row: Rating ⭐ 4.2 (Caption, #E8DCCC) • Pages 430 (Caption, #A89E90) • Genre tags (chips, #2A2A2A bg, #A89E90 text)
3. DROP-RISK WARNING CARD (critical — most important element):
   - Full-width card, surface #2A1A1A (subtle red tint), 12dp radius, 16dp padding, 16dp margin horizontal, 12dp gap from hero
   - Row 1: ⚠️ icon (24dp, #CC4444) + "DROP RISK: HIGH" (Title, #CC4444) — icon + text, NOT colour alone
   - Row 2: Reason text (Body, #F5F0E8) — e.g., "You dropped 3 of 4 long, dense books. Consider a shorter novel."
   - Row 3: [Dismiss] button (Ghost, 40dp h, #CC4444 text) — hides warning for this book
   - ACCESSIBILITY: role=alert, accessibilityLabel="Warning: High drop risk. You dropped 3 of 4 long dense books. Consider a shorter novel. Button: Dismiss"
4. Best Price Summary Card:
   - Surface #1A1A1A, 12dp radius, 16dp padding
   - "Best price" label (Caption, #A89E90)
   - Seller name + price (Headline, #E8DCCC) — e.g., "Seller A · EGP 210"
   - Delivery (Caption, #44CC44) — "2 days delivery"
5. Primary Actions (16dp horizontal margin, 12dp gap):
   - [Compare all prices] — Outlined button, 56dp h, #E8DCCC border/text
   - [Add to library] — Filled button, 56dp h, #E8DCCC bg, #0D0D0D text (PRIMARY)
   - If drop risk = HIGH: Add to library shows confirmation modal (see below)
6. Bottom navigation bar (same as Search Results)

CONFIRMATION MODAL (triggered when Drop Risk = HIGH and user taps "Add to library"):
- Centered sheet, 320dp max width, surface #1A1A1A, 16dp radius
- Title: "High drop risk" (Headline, #CC4444)
- Body: "This book has a high drop risk for you. Add anyway?" (Body, #F5F0E8)
- Actions: [Cancel] (Ghost) | [Add anyway] (Filled, #CC4444 bg)

EMPTY / EDGE CASES:
- If < 5 books in history: Warning card shows "Not enough history yet — add more books to see drop risk." (no icon, neutral #2A2A2A bg, #A89E90 text)
- If no sellers: Hide Best Price card, show "Not available from tracked sellers"

ACCESSIBILITY REQUIREMENTS:
- Warning card: role=alert, announced immediately on screen load
- All buttons: accessibilityLabel with full context
- Cover image: accessibilityLabel="Crime and Punishment by Dostoyevsky, book cover"
- Rating: announced as "4.2 out of 5 stars"
- Touch targets ≥ 56dp
- Contrast: warning text #CC4444 on #2A1A1A = 5.2:1 ✅; reason text #F5F0E8 on #2A1A1A = 12.8:1 ✅
- Dynamic type: all text scales, card heights auto

DELIVERABLE:
Figma frame 390×844, dark + light variants. Include component variants: Warning card (High / Medium / Low / None), Button states (default/pressed/disabled/loading), Modal open/closed.
```

### Drop-Risk Variants (Component Spec)

| Risk Level | Background | Icon | Label Text | Border |
|------------|------------|------|------------|--------|
| HIGH | #2A1A1A | ⚠️ #CC4444 | "DROP RISK: HIGH" | 1dp #CC4444 |
| MEDIUM | #2A2A1A | ⚠️ #CCAA44 | "DROP RISK: MEDIUM" | 1dp #CCAA44 |
| LOW | #1A2A1A | ✅ #44CC44 | "DROP RISK: LOW" | 1dp #44CC44 |
| NONE (insufficient history) | #2A2A2A | — | "Not enough history yet" | 1dp #3A3A3A |

---

## Screen 3: Home (v2 — Improved from Existing)

### Prompt for AI Generation

```
Generate a HIGH-FIDELITY mobile screen for "Home v2" — an improved version of the existing Shelf home screen.

CONTEXT:
Existing v1 home screen (see preview.webp) has: Continue Reading card, "Read a New Book" recommendations, bottom nav (icon-only), theme toggle (sun icon only). Problems to fix: unlabelled nav, no progress bar, no sync indicator, theme toggle unlabelled.

LAYOUT (top to bottom):
1. Status bar area (system)
2. Navigation bar (64dp): "Shelf" logo/wordmark (left) + Theme toggle (right) — TOGGLE shows "Dark" / "Light" TEXT next to icon, 48dp hit area
3. Continue Reading Card (if in-progress book exists):
   - Surface #1A1A1A, 12dp radius, 16dp padding, 16dp horizontal margin
   - Cover (60×90dp, 6dp radius)
   - Title (Body, #F5F0E8) + Author (Caption, #A89E90)
   - Progress row: Progress bar (8dp h, 8dp radius, #E8DCCC fill, #2A2A2A track) + "68% · Page 248 of 367" (Caption, #A89E90)
   - Sync indicator: 🟢 "Synced 2 min ago" (Caption, #44CC44) — or 🟡 "Syncing..." / 🔴 "Offline"
   - [Continue Reading] button (Full width, Filled, 48dp h)
4. Recommendations Section:
   - Section header: "Recommended for You" + [See All] (Caption, #E8DCCC)
   - Horizontal scroll: Book cards (120×180 cover + title + author + drop-risk badge inline)
   - Drop-risk badge on card: Small pill, 20dp h, "Low Risk" / "Med Risk" / "High Risk" with colour + text
5. Stats Summary (compact, 3 columns):
   - Books read: "12" (Display, #E8DCCC) + "books" (Caption, #A89E90)
   - Pages: "3,284" + "pages"
   - Time: "47h" + "hours"
   - Each in 100dp wide column, centered
6. Bottom Navigation Bar (88dp, fixed, labelled):
   - Home (active) | Search | Library | Profile
   - Icon 24dp + Caption label 4dp below
   - Active: #E8DCCC, Inactive: #A89E90
   - Background: #0D0D0D with top border 1dp #2A2A2A

ACCESSIBILITY FIXES FROM V1:
- Bottom nav: every item has accessibilityLabel ("Home, selected" / "Search" / "Library" / "Profile")
- Theme toggle: accessibilityLabel="Dark mode, double tap to switch to Light mode"
- Progress bar: accessibilityValue="68 percent", role=progressbar
- Sync indicator: announced on change
- Recommendation cards: each has drop-risk in label ("Crime and Punishment, High drop risk")

DELIVERABLE:
390×844 frame, dark + light. Annotate what changed from v1.
```

---

## Screen 4: Profile (v2 — Improved)

### Prompt for AI Generation

```
Generate a HIGH-FIDELITY mobile screen for "Profile v2" — improved from existing v1.

CONTEXT:
Existing v1 (preview.webp): Stats with grammar issues ("12 Book", "3284 Page", "47 hour"), Sign Out duplicated (bottom nav + profile), unlabelled icons, streak visual unclear.

LAYOUT (top to bottom):
1. Nav bar: "Profile" title + Settings gear (right)
2. Profile Header (120dp h):
   - Avatar (80dp, editable), Name (Title), @username (Caption), "Joined Jan 2024" (Caption)
3. Stats Grid (2×2, equal columns, 16dp gap, 16dp margin):
   - Card: "Books Completed" — Value "12" (Display, #E8DCCC) + Label "books" (Caption)
   - Card: "Pages Read" — Value "3,284" + Label "pages"
   - Card: "Reading Time" — Value "47h" + Label "hours"
   - Card: "Current Streak" — Value "14" + Label "days" + 🔥 icon
   - Cards: surface #1A1A1A, 12dp radius, 16dp padding, centered text
4. Reading History (list, navigate to full history):
   - Section header + [See All]
   - Recent books (3 max): Cover (40×60) + Title + Author + Progress badge (e.g., "100%")
5. Settings List (grouped, 16dp margin):
   - Group 1: Reading Preferences
     * Default language [English ▼]
     * Drop-risk sensitivity [Balanced ▼] (Low / Balanced / High)
   - Group 2: Sync & Backup
     * iCloud / Google Drive sync [ON toggle]
     * Last synced: "2 min ago" (Caption)
   - Group 3: Account
     * Edit Profile
     * Sign Out (Destructive: #CC4444 text, confirmation modal)
6. No bottom nav on Profile (or keep but Profile active)

FIXES FROM V1:
- Grammar: "12 books", "3,284 pages", "47 hours"
- Sign Out: ONLY here (not in bottom nav), destructive style, confirmation modal
- All labels: text + icon, no icon-only
- Streak: clear "14 days" + flame icon
- Sync status visible

DELIVERABLE:
390×844, dark + light.
```

---

## Screen 5: Onboarding / First Launch (Optional but Impressive)

### Prompt for AI Generation

```
Generate a 3-screen ONBOARDING flow for Shelf (mobile, dark theme).

SCREEN 1: Value Proposition
- Illustration: open book with price tag + sync icon
- Title: "Find the best price. Never lose your place."
- Body: "Search any book. See local sellers first, sorted by price. Your progress syncs instantly across devices."
- [Get Started] (Primary, full width)

SCREEN 2: Drop-Risk Promise
- Illustration: warning shield + heart
- Title: "Don't waste money on books you'll drop"
- Body: "Shelf learns your patterns. If a book has a high drop risk for YOU, we'll tell you why — before you buy."
- [Continue] (Primary)

SCREEN 3: Permissions & Sync
- Title: "Sync your library everywhere"
- Body: "Enable iCloud / Google Drive backup. Your progress, notes, and drop-risk model stay private and synced."
- Toggle: "Enable Sync" [ON]
- [Finish Setup] → Home screen

ACCESSIBILITY:
- All screens: swipe gestures have button alternatives
- Illustrations: decorative (accessibilityElementsHidden=true)
- Focus order logical
- Dynamic type throughout
```

---

## Figma File Structure (for Team Handoff)

```
/Shelf-Wireframes
  /01-Existing-v1 (from preview.webp)
    ├── Home-v1
    └── Profile-v1
  /02-New-v2-LoFi (rough, for flow testing)
    ├── Search-Results-LoFi
    ├── Book-Detail-LoFi
    └── User-Flow-LoFi
  /03-New-v2-HiFi (polished, for presentation)
    ├── Search-Results-HiFi
    ├── Book-Detail-HiFi
    ├── Home-v2
    ├── Profile-v2
    └── Onboarding
  /04-Components
    ├── Buttons (Primary/Outlined/Ghost/Destructive, all states)
    ├── Seller Card
    ├── Book Card
    ├── Drop-Risk Badge (4 variants)
    ├── Bottom Nav
    ├── Progress Bar
    ├── Sync Indicator
    └── Form Controls (Toggle, Select, Text Field)
  /05-Accessibility-Annnotations
    ├── Contrast audit screenshots
    ├── Touch target overlay
    ├── Screen reader labels spec
    └── Focus order diagrams
```

---

## Quick Test Prompts (for v0.dev / Galileo / Magic Patterns)

### One-Liner for Search Results
> "Mobile dark theme search results screen for a book price comparison app. Local sellers first (price ascending), then overseas. Seller cards with name, price, delivery, select button. Labelled bottom nav. Figma-ready, accessibility annotated."

### One-Liner for Book Detail
> "Mobile dark theme book detail screen with prominent drop-risk warning card (icon + text + reason, not colour-only), best price summary, compare prices and add to library buttons. High drop risk triggers confirmation modal. Accessibility: role=alert on warning, labelled everything."

### One-Liner for Home v2
> "Mobile dark theme home screen for reading tracker: continue reading card with progress bar + sync indicator, recommendations carousel with inline drop-risk badges, stats grid, labelled bottom nav, labelled theme toggle. Fixes: v1 had icon-only nav, no progress bar, no sync status."

---

## Handoff Checklist for Teammates

- [ ] All screens: 390×844 (iPhone 14/15) + 430×932 (Pro Max) variants
- [ ] Dark + Light mode for every screen
- [ ] Component library published (buttons, cards, badges, nav, form controls)
- [ ] Accessibility annotation layer visible (labels, focus order, contrast)
- [ ] Prototype links: Search → Results → Book Detail → Seller → Library
- [ ] Exported SVGs for presentation slides
- [ ] Figma file shared with view access for prof