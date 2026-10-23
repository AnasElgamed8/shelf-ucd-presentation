# Shelf — UCD Presentation Content

**App name:** Shelf
**Team:** Anas Hossam (Presenter: Sections 1, 4, 7), Youssef Hussein (Presenter: Sections 2, 5), Hozyfa Batisha (Presenter: Sections 3, 6)
**Course:** C# / UX module
**Format:** 1-hour presentation, PowerPoint
**Theme:** Dark (black #0D0D0D, beige #E8DCCC accent, off-white #F5F0E8 text)

---

## SECTION 1: Why User-Centred Design? (Anas — ~8 min)

### Slide 1.1 — Title: Why User-Centred Design?
**Speaker notes:** This section covers three things: what UCD is, the cost curve of fixing errors, and where UX work sits in the SDLC.

---

### Slide 1.2 — What is User-Centred Design?
**Definition:** UCD is an iterative design process where users' goals, tasks, and context drive every decision, and the design is validated with real users at every stage.

**Key points:**
- Users are involved from requirements through release
- Decisions are evidence-based, not assumption-based
- ISO 13407 / ISO 9241-210 standardises the process

**Speaker notes:** "UCD isn't about making things pretty. It's about making sure we're building the *right* thing before we build the thing right."

---

### Slide 1.3 — Cost of Fixing Errors: The Rising Curve
**Core message:** A requirement error found in requirements costs 1× to fix. Found in design: ~3–6×. Found in code: ~10–15×. Found in testing: ~30–50×. Found after release: ~100×.

**Shelf example:** If we build integrations with 6 bookstore APIs assuming users want a *list of all prices*, but users actually only want *the single cheapest local offer*, discovering this after launch means rewriting the aggregation logic, renegotiating API contracts, and losing trust. Finding it in a paper prototype costs a sticky note.

> **Note:** Exact multipliers (100×) are debated in literature (Boehm, NASA, McConnell). The *trend* is undisputed. We show the curve, not the numbers.

---

### Slide 1.4 — Usability: ISO 9241-11
**Definition:** "The extent to which a product can be used by specified users to achieve specified goals with **effectiveness**, **efficiency**, and **satisfaction** in a **specified context of use**."

| Dimension | Question | Shelf Example |
|-----------|----------|---------------|
| **Effectiveness** | Can users complete the goal accurately? | Reader finds a book and sees the cheapest local offer |
| **Efficiency** | How much effort/time/taps? | Result in ≤3 taps; progress logged without typing |
| **Satisfaction** | Does it feel comfortable and trustworthy? | Honest drop warnings, no pushy recommendations |
| **Context of use** | Who, what, where, on what? | Readers; comparing/tracking; commute/bed/bookstore; phone |

**Speaker notes:** "Context of use is the most overlooked part. A reader on a crowded Cairo metro at 8 AM with one hand free has different needs than someone on a couch at 10 PM."

---

### Slide 1.5 — Where UX Sits in the SDLC
**Diagram:** See Mermaid diagram `sdlc-ux-placement.mmd`

**Phases & UX Activities:**

| SDLC Phase | UX Activities |
|------------|---------------|
| **Research & Requirements** | User interviews, surveys, stakeholder map, personas, problem statement |
| **Design & Prototype** | User flows, low-fi wireframes, heuristic evaluation, paper/clickable prototype testing |
| **Implementation** | Design handoff, accessibility annotations, developer Q&A |
| **Test & Evaluate** | Usability testing with real tasks (not "does it crash?"), analytics review |
| **Release & Feedback** | App store reviews, support tickets, usage analytics → next iteration |

**Key message:** UX is not a phase. It's a thread that runs *before* design, *during* testing, and *after* release.

---

## SECTION 2: Users, Stakeholders & User Research (Youssef — ~8 min)

### Slide 2.1 — Title: Users, Stakeholders & Research

---

### Slide 2.2 — Users vs Stakeholders

**Primary Users:** Use the app directly and often.
- Readers who search for books, compare prices, log progress, get recommendations

**Secondary Users:** Use it occasionally or through someone else.
- Gift buyers (search once for a specific title)
- Friends sharing reading lists
- Support staff handling "wrong price" reports

**Stakeholders:** Affect or are affected by the product, even if they never open it.
- Bookstores (local & overseas) — want visibility, fair ranking
- Marketplace APIs (Amazon, BookDepository, etc.) — rate limits, terms of service
- App stores (Google Play, App Store) — guidelines, revenue share
- Development team — maintenance, technical debt
- Instructor / evaluator — grading criteria
- Authors & publishers — discoverability, pricing control
- Payment/affiliate partners — conversion tracking

**Speaker notes:** "Every stakeholder has a goal. Our job is to balance them without harming the primary user."

---

### Slide 2.3 — User Research Methods

| Method | Strengths | Limits | Shelf Application |
|--------|-----------|--------|-------------------|
| **Interviews** | Deep context, "why" behind behaviour, follow-up questions | Small sample, time-consuming, interviewer bias | 5–8 readers: "Walk me through the last time you bought a book" |
| **Questionnaires** | Larger sample, quantifiable, remote-friendly | No follow-up, self-report bias, shallow | 20+ readers: frequency, pain points, price sensitivity, drop reasons |
| **Observation** | Real behaviour, not self-reported; context visible | Observer effect, no "why", privacy/ethics | Watch 3 users compare prices across tabs/sites (screen-record with consent) |

**Triangulation:** Use at least two methods. Interviews + questionnaires = qualitative depth + quantitative breadth.

---

### Slide 2.4 — Stakeholder Map: Power/Interest Grid
**Diagram:** See Mermaid diagram `stakeholder-map.mmd`

**Quadrants:**

| Quadrant | Stakeholders | Strategy |
|----------|--------------|----------|
| **Manage Closely** (High Power, High Interest) | Development team, Instructor (evaluator) | Frequent communication, involve in decisions |
| **Keep Satisfied** (High Power, Low Interest) | Marketplaces & bookstore APIs, App stores | Meet requirements, monitor policy changes |
| **Keep Informed** (Low Power, High Interest) | Readers (primary users), Local bookstores, Authors & publishers | Regular updates, feedback channels |
| **Monitor** (Low Power, Low Interest) | Review sites, Payment/affiliate partners | Periodic check, no active management |

---

## SECTION 3: Personas (Hozyfa — ~8 min)

### Slide 3.1 — Title: Personas

---

### Slide 3.2 — What is a Persona?
**Definition:** A fictional but realistic archetype of a key user group, synthesised from research data.

**Contents:**
- Name, photo, age, location, role
- Goals (what they want to achieve)
- Frustrations / pain points (what blocks them)
- Technical skills & device context
- Behaviours / habits relevant to the product
- Quote capturing their attitude

**Golden rule:** Personas must be based on **evidence** (interviews, surveys, analytics), not stereotypes or team assumptions. An invented persona creates false confidence.

---

### Slide 3.3 — Proto-Persona: Layla Hassan
**Status:** Proto-persona — built from team experience and informal conversations. Next step: validate with 5+ interviews.

| Field | Detail |
|-------|--------|
| **Name** | Layla Hassan |
| **Age / Role** | 21, university student (Cairo) |
| **Languages** | Reads English and Arabic |
| **Budget** | Buys 1–2 books/month on student budget |
| **Context** | Phone-first; reads on commute (metro) and before sleep |
| **Tech skills** | High with phones/apps. Low patience for setup/sign-up walls. |
| **Goals** | 1. Find a book at the lowest *local* price<br>2. Keep her reading habit going (streak)<br>3. Pick books she will actually finish |
| **Frustrations** | 1. Comparing prices across browser tabs<br>2. Losing her place when switching devices<br>3. Paying for books she abandons halfway |
| **Quote** | *"I just want to know: where's the cheapest copy near me, and will I actually finish this one?"* |

**Evidence traceability:** Each goal/frustration maps to a research question in our questionnaire.

---

## SECTION 4: User Stories & Acceptance Criteria (Anas — ~8 min)

### Slide 4.1 — Title: User Stories & Acceptance Criteria

---

### Slide 4.2 — User Story Format & INVEST
**Format:** `As a <role>, I want <goal>, so that <benefit>.`

**INVEST Criteria:**

| Criterion | Meaning | Shelf Check |
|-----------|---------|-------------|
| **Independent** | Minimal dependencies between stories | Story 3 depends on Story 2 → flagged |
| **Negotiable** | Details co-created with team, not a contract | All stories have room for negotiation |
| **Valuable** | Delivers value to user or stakeholder | All three pass |
| **Estimable** | Team can size it | Story 2 has sync-conflict risk |
| **Small** | Fits in one sprint | Story 1 needs country-scoping |
| **Testable** | Clear pass/fail via acceptance criteria | All use Given/When/Then |

---

### Slide 4.3 — Story 1: Compare Prices (Local First)
**Story:** As a **reader**, I want to **search a title and see local sellers first, sorted by price**, so that **I can buy it cheaply and quickly**.

**Acceptance Criteria (Given/When/Then):**
1. **Given** I am in country X and search "Crime and Punishment", **When** results load, **Then** local sellers appear first, sorted by price ascending, each showing price, delivery time, and seller name.
2. **Given** no local seller has the book, **When** results load, **Then** overseas sellers appear with an "Overseas" label, delivery estimate, and total cost (price + shipping).
3. **Given** the search fails (network/API error), **When** the error occurs, **Then** a clear message appears: "Couldn't reach sellers. Check connection or try again." with a retry button.

---

### Slide 4.4 — Story 2: Synced Reading Progress
**Story:** As a **reader**, I want **my progress synced across devices**, so that **I can continue where I stopped on any device**.

**Acceptance Criteria:**
1. **Given** I read to page 100 on my phone, **When** I open the app on a tablet, **Then** it shows page 100 within 5 seconds (with "Synced" indicator).
2. **Given** I am offline, **When** I read 20 pages, **Then** progress is saved locally and synced automatically on reconnect.
3. **Given** I read on two devices offline, **When** both reconnect, **Then** the later timestamp wins (last-write-wins) and a toast confirms "Progress merged from [device]".

---

### Slide 4.5 — Story 3: Drop-Risk Warning
**Story:** As a **reader**, I want **a warning when a book is likely to be dropped**, so that **I do not waste money on it**.

**Acceptance Criteria:**
1. **Given** I have 5+ books in my history, **When** I open a book's detail page, **Then** I see a drop-risk level (Low / Medium / High) with a one-line reason (e.g., "You dropped 3 of 4 long, dense books").
2. **Given** fewer than 5 books in history, **When** I open a book's detail page, **Then** I see "Not enough history yet — add more books to see drop risk."
3. **Given** the drop risk is High, **When** I tap "Add to library", **Then** a confirmation modal appears: "This book has a high drop risk for you. Add anyway?" with [Cancel] [Add].

---

### Slide 4.6 — INVEST Review (Self-Critique)
**Diagram:** See Mermaid diagram `invest-review.mmd`

| Story | I | N | V | E | S | T | Notes |
|-------|---|---|---|---|---|---|-------|
| 1: Compare prices | ✅ | ✅ | ✅ | ⚠️ | ⚠️ | ✅ | Estimable if country scope fixed; Small if one country per sprint |
| 2: Synced progress | ✅ | ✅ | ✅ | ⚠️ | ✅ | ✅ | Sync conflict rule needed before sizing |
| 3: Drop warning | ❌ | ✅ | ✅ | ✅ | ✅ | ✅ | Depends on history from Story 2. Fix: split into "collect history" + "show warning" |

**Speaker notes:** "We're honest about the gaps. Acknowledging INVEST failures shows we understand the criteria."

---

## SECTION 5: Problem Statement & User Flow (Youssef — ~8 min)

### Slide 5.1 — Title: Problem Statement & User Flow

---

### Slide 5.2 — Problem Statement (118 words)

> **Readers buy books from many stores, yet no single place shows who sells a title nearby, at what price, and how soon it arrives. They open multiple tabs, compare manually, and still overpay or wait weeks for overseas shipping. At the same time, they abandon books they never finish — wasting money and breaking their reading habit. Existing apps either track reading *or* compare prices, but not both, and none warn a reader "you'll likely drop this" based on their actual history. Students and budget-conscious readers are hit hardest: they have the least money to waste and the least time to hunt. A unified app that aggregates local-first prices, syncs progress effortlessly, and predicts drop risk from personal patterns would save money, reduce friction, and help readers build a sustainable habit.**

**Structure check:**
- **Who:** Readers, especially students / budget-conscious
- **What:** Fragmented price comparison + no drop prediction + no unified tracking
- **Why it matters:** Wasted money, broken habits, time lost

---

### Slide 5.3 — User Flow: Find and Buy a Book
**Diagram:** See Mermaid diagram `user-flow.mmd`

**Happy Path (6 steps):**
1. Open app → Home screen
2. Tap Search → Enter title/author/ISBN
3. Results load → Local sellers first (price ↑), then Overseas
4. Tap a result → Book detail screen (cover, description, drop risk, best price)
5. Tap "Compare prices" → Full seller list with deep links
6. Tap seller → External browser/app → Purchase → "Add to library" → Library screen

**Error Path:**
- At step 3: **No results OR network/API error** → Inline message: *"No local results for 'X'. Try a different spelling, author name, or check connection."* → [Retry] [Search author] [Browse categories]
- At step 6: **Seller deep link fails** → Toast: *"Couldn't open seller. Copy link?"* → [Copy] [Dismiss]

**No dead ends.** Every error has a recovery action.

---

## SECTION 6: Wireframes & Usability Heuristics (Hozyfa — ~8 min)

### Slide 6.1 — Title: Wireframes & Usability Heuristics

---

### Slide 6.2 — Low-Fidelity vs High-Fidelity

| Aspect | Low-Fidelity | High-Fidelity |
|--------|--------------|---------------|
| **Visuals** | Boxes, labels, placeholders | Colours, typography, real images, spacing |
| **Speed** | Minutes to create/change | Hours to create/change |
| **Focus** | Layout, flow, structure, IA | Visual hierarchy, contrast, polish, details |
| **When to use** | Early exploration, flow testing, stakeholder alignment | Usability testing (visual), dev handoff, stakeholder sign-off |
| **Tools** | Paper, whiteboard, Figma (wireframe mode), draw.io | Figma, Sketch, Adobe XD |

**Our approach:** Start lo-fi for new screens (search, book detail). Keep existing hi-fi (home, profile) as v1 baseline, then show v2 improvements.

---

### Slide 6.3 — Existing High-Fidelity Screens (v1)
**Images:** `preview.webp` (contains both screens)

**Screen 1 — Home:**
- Continue reading card (cover, progress text "100 / 367", progress bar missing)
- "Read a New Book" section (recommendations, no explanation why)
- Bottom nav: Home | Search | Library | Profile (icons only, no labels)
- Theme toggle (sun icon, no label)

**Screen 2 — Profile:**
- Stats: "12 Book", "3284 Page", "47 hour" (grammar: should be plural)
- Streak & time visualisations
- Settings | Sign Out (Sign Out duplicated: also in bottom nav)
- Dark theme (chosen for night reading)

**Known gaps:** No price comparison, no drop warning, no search results, no book detail with seller list.

---

### Slide 6.4 — New Low-Fidelity Screens (v2) — Core Value

#### Screen A: Search Results
```
┌─────────────────────────────────────┐
│  ← Back          Search: Crime...   │
├─────────────────────────────────────┤
│  📍 LOCAL SELLERS (sorted by price) │
│  ┌───────────────────────────────┐  │
│  │ 🏪 Seller A (Local)           │  │
│  │ EGP 210  •  2 days delivery   │  │
│  │ [Select]                      │  │
│  └───────────────────────────────┘  │
│  ┌───────────────────────────────┐  │
│  │ 🏪 Seller B (Local)           │  │
│  │ EGP 245  •  3 days delivery   │  │
│  │ [Select]                      │  │
│  └───────────────────────────────┘  │
│  🌍 OVERSEAS SELLERS                │
│  ┌───────────────────────────────┐  │
│  │ 🌐 Seller C (Overseas)        │  │
│  │ EGP 330  •  12 days delivery  │  │
│  │ [Select]                      │  │
│  └───────────────────────────────┘  │
├─────────────────────────────────────┤
│  Home   Search   Library   Profile  │  ← Labelled nav
└─────────────────────────────────────┘
```

#### Screen B: Book Detail (with Drop Warning)
```
┌─────────────────────────────────────┐
│  ← Back          Book Details       │
├─────────────────────────────────────┤
│  [Cover]   Crime and Punishment     │
│           Dostoyevsky               │
│           ⭐ 4.2  •  430 pages       │
├─────────────────────────────────────┤
│  ⚠  DROP RISK: HIGH                 │
│  You dropped 3 of 4 long, dense     │
│  books. Consider a shorter novel.   │
│  [Dismiss]                          │
├─────────────────────────────────────┤
│  Best price: Seller A · EGP 210     │
│  [Compare all prices]  [Add to lib] │
├─────────────────────────────────────┤
│  Home   Search   Library   Profile  │
└─────────────────────────────────────┘
```

**Key accessibility features in v2:**
- Labelled bottom navigation (text + icon)
- Drop risk uses icon (⚠) + text (HIGH) + reason — **not colour alone**
- Clear button labels, touch targets ≥48dp

---

### Slide 6.5 — Nielsen's 10 Usability Heuristics
1. **Visibility of system status** — Keep users informed
2. **Match between system & real world** — Familiar language, conventions
3. **User control & freedom** — Emergency exits, undo
4. **Consistency & standards** — Platform conventions, internal consistency
5. **Error prevention** — Prevent errors before they happen
6. **Recognition over recall** — Make options visible
7. **Flexibility & efficiency of use** — Shortcuts for experts
8. **Aesthetic & minimalist design** — No irrelevant info
9. **Help users recognise, diagnose, recover from errors** — Plain language, constructive
10. **Help & documentation** — Searchable, task-focused

---

### Slide 6.6 — Three Heuristics Applied to Our Wireframes
**Diagram:** See Mermaid diagram `heuristics-applied.mmd`

| Heuristic | v1 Problem (Existing Hi-Fi) | v2 Fix (New Lo-Fi / Planned) |
|-----------|----------------------------|------------------------------|
| **#5 Error Prevention** | Logout icon in bottom nav next to Profile/Settings — easy accidental tap. Sign Out duplicated on Profile. | Removed from bottom nav. Single "Sign Out" on Profile with confirmation modal. |
| **#1 Visibility of System Status** | Progress shown only as "100 / 367" text. No sync indicator. | Progress bar + percentage. "Synced ✓" / "Syncing..." indicator on Library & Home. |
| **#6 Recognition over Recall** | Bottom nav icons only (no labels). Theme toggle = sun icon only. | Text labels under every nav icon. Theme toggle shows "Light / Dark" text. |

> **Note:** v2 fixes for #1 and #5 are *planned* — not yet drawn in the hi-fi screens. The lo-fi v2 screens show labelled nav (#6).

---

## SECTION 7: Accessibility (Anas — ~8 min)

### Slide 7.1 — Title: Accessibility

---

### Slide 7.2 — Why Accessibility Matters & POUR
**Why:** ~15% of world population has a disability. Accessible design helps everyone (curb cut effect). Legal risk (EAA 2025, ADA, etc.). Better UX for all.

**WCAG 2.1 Four Principles (POUR):**

| Principle | Meaning | Shelf Application |
|-----------|---------|-------------------|
| **Perceivable** | Users can see/hear content | 4.5:1 contrast, alt text for covers, scalable text |
| **Operable** | Users can control it | Touch targets ≥48dp, no gesture-only actions, skip links |
| **Understandable** | Clear, predictable, helpful errors | Plain language, consistent nav, inline validation messages |
| **Robust** | Works with AT, different devices | Semantic HTML/Accessibility API, tested with TalkBack/VoiceOver |

---

### Slide 7.3 — Practical Rules: Desktop → Mobile Mapping
**Brief asks for desktop rules. We adapt to mobile honestly.**

| Desktop Rule (Brief) | Mobile Equivalent (Shelf) | Status |
|----------------------|---------------------------|--------|
| Text contrast ≥ 4.5:1 | Text contrast ≥ 4.5:1 (AA) / 7:1 (AAA for body) | ✅ Check with APCA/contrast tool |
| Full keyboard navigation | Full **touch** navigation: all actions reachable via TalkBack/VoiceOver, logical focus order | ✅ Labelled nav, semantic buttons |
| Never colour alone for meaning | Never colour alone: drop risk uses icon + text + pattern | ✅ v2 book detail |
| Clear labels for every input | Clear labels for every input: Search field has "Search books..." placeholder + label; no icon-only buttons | ✅ v2 screens |

**Speaker notes:** "We didn't ignore the brief — we translated it. The principles are identical; the implementation differs by platform."

---

### Slide 7.4 — Accessibility Checklist on Our Wireframes

| # | Criterion | Home (v1) | Profile (v1) | Search (v2) | Book Detail (v2) | Action |
|---|-----------|-----------|--------------|-------------|------------------|--------|
| 1 | Text contrast ≥ 4.5:1 (body) | ❌ Grey on dark grey likely fails | ❌ Stats labels low contrast | ✅ Designed for contrast | ✅ Designed for contrast | Audit with tool |
| 2 | Text contrast ≥ 3:1 (large text) | ✅ Title text passes | ✅ Headers pass | ✅ | ✅ | Verify |
| 3 | Touch targets ≥ 48×48dp | ❌ Nav icons small | ⚠️ Buttons OK | ✅ 56dp min | ✅ 56dp min | Enlarge v1 nav |
| 4 | No colour-only meaning | ⚠️ Theme icon only | ❌ Streak colour only | ✅ N/A | ✅ Icon+text+risk word | Fix v1 streak |
| 5 | Labels on all inputs/buttons | ❌ Nav icons unlabelled | ✅ Buttons labelled | ✅ All labelled | ✅ All labelled | Add labels v1 |
| 6 | Focus/traversal order logical | ⚠️ Unknown | ⚠️ Unknown | ✅ Top→bottom | ✅ Top→bottom | Test with TalkBack |
| 7 | Text resizing (dynamic type) | ⚠️ Unknown | ⚠️ Unknown | ✅ Relative units | ✅ Relative units | Test |
| 8 | Screen reader labels | ❌ Missing on icon buttons | ⚠️ Partial | ✅ `accessibilityLabel` on all | ✅ `accessibilityLabel` on all | Add to v1 |
| 9 | Error messages clear & actionable | N/A | N/A | ✅ Inline + retry | ✅ Modal + cancel | — |
| 10 | Dark mode support | ✅ Default | ✅ Default | ✅ Designed for both | ✅ Designed for both | Verify light mode |

**Status legend:** ✅ Pass | ⚠️ Partial/Unknown | ❌ Fail | N/A Not applicable

---

### Slide 7.5 — Summary & Next Steps
- UCD finds problems when they're cheap to fix
- Users, stakeholders, research → who we design for
- Persona & stories → testable requirements
- Problem statement, flow, wireframes → concrete idea
- Heuristics & accessibility checks → better design
- **Next:** Validate persona with real interviews. Usability-test the wireframes. Iterate.

---

### Slide 7.6 — Questions?
**Contact:** Anas Hossam · Youssef Hussein · Hozyfa Batisha