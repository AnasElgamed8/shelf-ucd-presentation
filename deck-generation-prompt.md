# PowerPoint Generation Prompt for Shelf UCD Presentation

**Use this prompt with:** GPT-4o, Claude 3.5 Sonnet, Gemini 2.5 Pro, or any model with python-pptx / python-pptx-template / Office.js / Marp / Deck.js / Reveal.js capability.

**Output:** A polished `.pptx` file (preferred) or markdown deck exportable to PPTX.

---

## Global Design System (NON-NEGOTIABLE)

```json
{
  "theme": "dark",
  "colours": {
    "background": "#0D0D0D",
    "surface": "#1A1A1A",
    "surfaceElevated": "#242424",
    "primary": "#E8DCCC",
    "primaryHover": "#D4C4A8",
    "textPrimary": "#F5F0E8",
    "textSecondary": "#A89E90",
    "textMuted": "#6A6358",
    "error": "#CC4444",
    "errorBg": "#2A1A1A",
    "success": "#44CC44",
    "successBg": "#0D2A1A",
    "warning": "#CCAA44",
    "warningBg": "#2A2A1A",
    "divider": "#2A2A2A",
    "overlay": "rgba(13,13,13,0.9)"
  },
  "typography": {
    "fontFamily": "System UI, -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif",
    "scale": {
      "display": { "size": 44, "lineHeight": 52, "weight": 700, "letterSpacing": "-0.5px" },
      "headline": { "size": 32, "lineHeight": 40, "weight": 600, "letterSpacing": "-0.25px" },
      "title": { "size": 24, "lineHeight": 32, "weight": 600 },
      "body": { "size": 18, "lineHeight": 28, "weight": 400 },
      "bodySmall": { "size": 16, "lineHeight": 24, "weight": 400 },
      "caption": { "size": 14, "lineHeight": 20, "weight": 400 },
      "overline": { "size": 12, "lineHeight": 16, "weight": 600, "letterSpacing": "1px", "textTransform": "uppercase" }
    }
  },
  "spacing": { "base": 8, "scale": [0, 4, 8, 12, 16, 24, 32, 48, 64] },
  "borderRadius": { "sm": 6, "md": 12, "lg": 16, "full": 9999 },
  "shadows": {
    "elev1": "0 1px 3px rgba(0,0,0,0.3)",
    "elev2": "0 4px 12px rgba(0,0,0,0.4)",
    "elev3": "0 8px 24px rgba(0,0,0,0.5)"
  },
  "slideDimensions": { "width": 13.333, "height": 7.5, "unit": "in" }
}
```

---

## Slide Master Layouts Required

| Layout Name | Description | Placeholders |
|-------------|-------------|--------------|
| `TitleSlide` | Full-screen background, centred title, subtitle, team names | Title, Subtitle, Team |
| `SectionHeader` | Large section number + title, thin accent line | Section Number, Section Title |
| `ContentLeft` | Left: text content (bullets, paragraphs). Right: diagram/image | Title, Body, Visual |
| `ContentRight` | Mirror of ContentLeft | Title, Body, Visual |
| `TwoColumn` | 50/50 split, left text right visual or vice versa | Title, LeftBody, RightBody |
| `TableSlide` | Full-width styled table | Title, Table |
| `CodeSlide` | Monospace block (for GWT, Mermaid) | Title, CodeBlock |
| `ImageFull` | Full-bleed image with optional caption | Image, Caption |
| `ChecklistSlide` | Table with status icons (✅ ⚠️ ❌) | Title, ChecklistTable |

---

## Slide-by-Slide Specification

### Slide 1: Title Slide (Layout: `TitleSlide`)
**Content:**
- **Title:** Shelf
- **Subtitle:** User-Centred Design for a Book Comparison & Reading Tracker App
- **Team:** Anas Hossam · Youssef Hussein · Hozyfa Batisha
- **Footer:** C# UX Module · [Date]

**Styling:** Title in Display style, primary colour. Subtitle in Headline, textSecondary. Team in Body, textMuted. Subtle book/icon illustration centred behind text (opacity 5%).

---

### Slide 2: Section 1 Header (Layout: `SectionHeader`)
**Content:**
- **Section Number:** 01
- **Section Title:** Why User-Centred Design?

**Styling:** Accent line (2px, primary) under section number.

---

### Slide 3: What is UCD? (Layout: `ContentLeft`)
**Title:** What is User-Centred Design?
**Body (bulleted, bodySmall):**
- An iterative design process where users' goals, tasks, and context drive every decision
- Designs are validated with real users at every stage
- Not about aesthetics — about building the *right* thing before building the thing right
- Standardised in ISO 9241-210 / ISO 13407
**Speaker Notes:** "UCD isn't about making things pretty. It's about making sure we're building the right thing before we build the thing right."

---

### Slide 4: Cost of Fixing Errors (Layout: `ContentRight`)
**Title:** Cost of Fixing Errors: The Rising Curve
**Visual:** Mermaid diagram `sdlc-ux-placement.mmd` rendered as SVG (see diagram-prompts.md)
**Body (bodySmall):**
- Requirements: 1× (baseline)
- Design: 3–6×
- Code: 10–15×
- Testing: 30–50×
- Release: ~100×
- **Shelf example:** Building 6 bookstore API integrations for "all prices" when users only want "cheapest local offer" → post-launch rewrite, renegotiated contracts, lost trust. On paper: a sticky note.
- *Exact multipliers debated (Boehm, NASA, McConnell); the exponential trend is not.*
**Speaker Notes:** "A requirement error found in requirements costs 1×. Found after release: ~100×. The numbers are debated; the curve is not."

---

### Slide 5: ISO 9241-11 Usability (Layout: `TableSlide`)
**Title:** Usability: ISO 9241-11
**Table:** (Styled: header row primary bg, alternating surface/surfaceElevated, textPrimary)
| Dimension | Definition | Shelf Example |
|-----------|------------|---------------|
| **Effectiveness** | Can users complete the goal accurately? | Reader finds a book and sees the cheapest local offer |
| **Efficiency** | How much effort, time, taps? | Result in ≤3 taps; progress logged without typing |
| **Satisfaction** | Does it feel comfortable and trustworthy? | Honest drop warnings, no pushy recommendations |
| **Context of Use** | Who, what, where, on what? | Readers; comparing/tracking; commute/bed/bookstore; phone |

**Speaker Notes:** "Context of use is the most overlooked part. A reader on a crowded Cairo metro at 8 AM with one hand free has different needs than someone on a couch at 10 PM."

---

### Slide 6: UX in the SDLC (Layout: `ContentLeft`)
**Title:** Where UX Work Sits in the SDLC
**Visual:** Mermaid timeline `sdlc-ux-placement.mmd` as SVG
**Body (bodySmall):**
- **Research & Requirements:** User interviews, surveys, stakeholder map, personas, problem statement
- **Design & Prototype:** User flows, lo-fi wireframes, heuristic evaluation, prototype testing
- **Implementation:** Design handoff, accessibility annotations, developer Q&A
- **Test & Evaluate:** Usability testing with real tasks (not "does it crash?"), analytics review
- **Release & Feedback:** App store reviews, support tickets, usage analytics → next iteration
- **Key message:** UX is not a phase. It's a thread running before, during, and after.

---

### Slide 7: Section 2 Header (Layout: `SectionHeader`)
**Section Number:** 02
**Section Title:** Users, Stakeholders & Research

---

### Slide 8: Users vs Stakeholders (Layout: `TwoColumn`)
**Title:** Users vs Stakeholders
**Left Column (Primary Users):**
- **Primary Users:** Use the app directly and often
  - Readers who search, compare prices, log progress, get recommendations
- **Secondary Users:** Use occasionally or through others
  - Gift buyers, friends sharing lists, support staff

**Right Column (Stakeholders):**
- **Stakeholders:** Affect or are affected, even if they never open the app
  - Bookstores (local & overseas) — visibility, fair ranking
  - Marketplace APIs — rate limits, terms of service
  - App stores — guidelines, revenue share
  - Development team — maintenance, technical debt
  - Instructor / evaluator — grading criteria
  - Authors & publishers — discoverability, pricing control
  - Payment/affiliate partners — conversion tracking

---

### Slide 9: Research Methods (Layout: `TableSlide`)
**Title:** User Research Methods
**Table:**
| Method | Strengths | Limits | Shelf Application |
|--------|-----------|--------|-------------------|
| **Interviews** | Deep context, "why", follow-up | Small sample, time-consuming, bias | 5–8 readers: "Walk me through last book purchase" |
| **Questionnaires** | Larger sample, quantifiable, remote | No follow-up, self-report bias, shallow | 20+ readers: frequency, pain points, price sensitivity, drop reasons |
| **Observation** | Real behaviour, context visible | Observer effect, no "why", privacy | Watch 3 users compare prices across tabs (screen-record, consent) |

**Footnote:** Triangulation: use at least two methods. Interviews + questionnaires = depth + breadth.

---

### Slide 10: Stakeholder Map (Layout: `ContentRight`)
**Title:** Stakeholder Map: Power vs Interest
**Visual:** Mermaid quadrantChart `stakeholder-map.mmd` as SVG
**Body (bodySmall):**
- **Manage Closely (High/High):** Development Team, Instructor — frequent comms, involve in decisions
- **Keep Satisfied (High/Low):** Marketplaces & APIs, App Stores — meet requirements, monitor policy
- **Keep Informed (Low/High):** Readers, Local Bookstores, Authors & Publishers — regular updates, feedback channels
- **Monitor (Low/Low):** Review Sites, Payment/Affiliate Partners — periodic check

---

### Slide 11: Section 3 Header (Layout: `SectionHeader`)
**Section Number:** 03
**Section Title:** Personas

---

### Slide 12: What is a Persona? (Layout: `ContentLeft`)
**Title:** What is a Persona?
**Body (bulleted):**
- A fictional but realistic archetype of a key user group, synthesised from research data
- Contains: name, photo, age, location, role, goals, frustrations, technical skills, context of use, quote
- **Golden rule:** Must be based on **evidence** (interviews, surveys, analytics), not stereotypes or team assumptions
- An invented persona creates false confidence

---

### Slide 13: Proto-Persona: Layla Hassan (Layout: `TwoColumn`)
**Title:** Proto-Persona: Layla Hassan
**Left Column (Profile Card Style):**
- **Name:** Layla Hassan
- **Age/Role:** 21, university student (Cairo)
- **Languages:** English & Arabic
- **Budget:** 1–2 books/month (student budget)
- **Context:** Phone-first; commute (metro) & before sleep
- **Tech Skills:** High with phones/apps. Low patience for setup/sign-up walls.
- **Quote:** *"I just want to know: where's the cheapest copy near me, and will I actually finish this one?"*

**Right Column (Goals & Frustrations):**
**Goals:**
1. Find a book at the lowest *local* price
2. Keep her reading habit going (streak)
3. Pick books she will actually finish

**Frustrations:**
1. Comparing prices across browser tabs
2. Losing her place when switching devices
3. Paying for books she abandons halfway

**Status Badge:** 🟡 Proto-persona — Source: team experience + informal chats. Next: validate with 5+ interviews.

---

### Slide 14: Section 4 Header (Layout: `SectionHeader`)
**Section Number:** 04
**Section Title:** User Stories & Acceptance Criteria

---

### Slide 15: Story Format & INVEST (Layout: `ContentLeft`)
**Title:** User Story Format & INVEST Criteria
**Body:**
- **Format:** `As a <role>, I want <goal>, so that <benefit>.`
- **INVEST:**
  - **I**ndependent — minimal dependencies
  - **N**egotiable — details co-created, not a contract
  - **V**aluable — delivers value to user/stakeholder
  - **E**stimable — team can size it
  - **S**mall — fits in one sprint
  - **T**estable — clear pass/fail via acceptance criteria

---

### Slide 16: Story 1 — Compare Prices (Layout: `CodeSlide`)
**Title:** Story 1: Compare Prices (Local First)
**CodeBlock (monospace, primary text on surface bg):**
```
As a reader, I want to search a title and see local sellers
first sorted by price, so that I can buy it cheaply and quickly.

Acceptance Criteria (Given / When / Then):

1. Given I am in country X and search "Crime and Punishment"
   When results load
   Then local sellers appear first, sorted by price ascending,
   each showing price, delivery time, and seller name.

2. Given no local seller has the book
   When results load
   Then overseas sellers appear with an "Overseas" label,
   delivery estimate, and total cost (price + shipping).

3. Given the search fails (network/API error)
   When the error occurs
   Then a clear message appears:
   "Couldn't reach sellers. Check connection or try again."
   with a retry button.
```

---

### Slide 17: Story 2 — Synced Progress (Layout: `CodeSlide`)
**Title:** Story 2: Synced Reading Progress
**CodeBlock:**
```
As a reader, I want my progress synced across devices,
so that I can continue where I stopped on any device.

Acceptance Criteria (Given / When / Then):

1. Given I read to page 100 on my phone
   When I open the app on a tablet
   Then it shows page 100 within 5 seconds
   (with "Synced ✓" indicator).

2. Given I am offline
   When I read 20 pages
   Then progress is saved locally and synced automatically on reconnect.

3. Given I read on two devices offline
   When both reconnect
   Then the later timestamp wins (last-write-wins)
   and a toast confirms "Progress merged from [device]".
```

---

### Slide 18: Story 3 — Drop Warning (Layout: `CodeSlide`)
**Title:** Story 3: Drop-Risk Warning
**CodeBlock:**
```
As a reader, I want a warning when a book is likely to be dropped,
so that I do not waste money on it.

Acceptance Criteria (Given / When / Then):

1. Given I have 5+ books in my history
   When I open a book's detail page
   Then I see a drop-risk level (Low / Medium / High)
   with a one-line reason
   (e.g., "You dropped 3 of 4 long, dense books").

2. Given fewer than 5 books in history
   When I open a book's detail page
   Then I see "Not enough history yet — add more books to see drop risk."

3. Given the drop risk is High
   When I tap "Add to library"
   Then a confirmation modal appears:
   "This book has a high drop risk for you. Add anyway?"
   [Cancel] [Add anyway]
```

---

### Slide 19: INVEST Review (Layout: `TableSlide`)
**Title:** INVEST Review of Our Stories (Self-Critique)
**Table:**
| Story | Independent | Negotiable | Valuable | Estimable | Small | Testable | Notes |
|-------|-------------|------------|----------|-----------|-------|----------|-------|
| 1: Compare Prices | ✅ | ✅ | ✅ | ⚠️ | ⚠️ | ✅ | Country scope fixed; one country/sprint |
| 2: Synced Progress | ✅ | ✅ | ✅ | ⚠️ | ✅ | ✅ | Sync conflict rule needed before sizing |
| 3: Drop Warning | ❌ | ✅ | ✅ | ✅ | ✅ | ✅ | Depends on Story 2 history. Fix: split into "collect history" + "show warning" |

**Footnote:** Stories are conversation starters; acceptance criteria turn them into tests. Honest critique > fake pass.

---

### Slide 20: Section 5 Header (Layout: `SectionHeader`)
**Section Number:** 05
**Section Title:** Problem Statement & User Flow

---

### Slide 21: Problem Statement (Layout: `ContentLeft`)
**Title:** Problem Statement (118 words)
**Body (paragraph, bodySmall, primary text):**
> Readers buy books from many stores, yet no single place shows who sells a title nearby, at what price, and how soon it arrives. They open multiple tabs, compare manually, and still overpay or wait weeks for overseas shipping. At the same time, they abandon books they never finish — wasting money and breaking their reading habit. Existing apps either track reading *or* compare prices, but not both, and none warn a reader "you'll likely drop this" based on their actual history. Students and budget-conscious readers are hit hardest: they have the least money to waste and the least time to hunt. A unified app that aggregates local-first prices, syncs progress effortlessly, and predicts drop risk from personal patterns would save money, reduce friction, and help readers build a sustainable habit.

**Structure annotation (caption, textMuted):** Who: Readers (esp. students) · What: Fragmented comparison + no drop prediction + no unified tracking · Why: Wasted money, broken habits, time lost

---

### Slide 22: User Flow (Layout: `ImageFull`)
**Title:** User Flow: Find and Buy a Book
**Image:** Render `user-flow.mmd` as SVG (full width, max height 6.5in)
**Caption:** Happy path (6 steps) → Error path 1 (no results) → Error path 2 (seller link fails). No dead ends.

---

### Slide 23: Section 6 Header (Layout: `SectionHeader`)
**Section Number:** 06
**Section Title:** Wireframes & Usability Heuristics

---

### Slide 24: Low vs High Fidelity (Layout: `TwoColumn`)
**Title:** Low-Fidelity vs High-Fidelity Wireframes
**Left Column (Lo-Fi):**
- Boxes, labels, placeholders — no colour or branding
- Fast and cheap to change (minutes)
- Focus: layout, flow, structure, information architecture
- Use: early exploration, flow testing, stakeholder alignment
- Tools: paper, whiteboard, Figma wireframe mode, draw.io

**Right Column (Hi-Fi):**
- Close to final look: colours, typography, images, spacing
- Slower to change (hours)
- Focus: visual hierarchy, contrast, polish, details
- Use: usability testing (visual), dev handoff, stakeholder sign-off
- Tools: Figma, Sketch, Adobe XD

**Our approach:** Lo-fi for new screens (search, book detail). Existing hi-fi (home, profile) as v1 baseline → show v2 improvements.

---

### Slide 25: Existing Hi-Fi Screens v1 (Layout: `ImageFull`)
**Title:** Existing High-Fidelity Screens (v1)
**Image:** `preview.webp` (both screens side by side or stacked)
**Caption:** Home: Continue reading, recommendations, icon-only bottom nav, unlabelled theme toggle. Profile: Stats (grammar issues), duplicated Sign Out, dark theme for night reading. **Gaps:** No price comparison, no drop warning, no search results, no book detail with sellers.

---

### Slide 26: New Lo-Fi Screens v2 (Layout: `TwoColumn`)
**Title:** New Low-Fidelity Screens (v2) — Core Value
**Left Column (Search Results):**
```
┌─────────────────────────────────────┐
│  ← Back    Results: Crime...        │
├─────────────────────────────────────┤
│  📍 LOCAL SELLERS (3)               │
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
│  🌍 OVERSEAS SELLERS (2)            │
│  ┌───────────────────────────────┐  │
│  │ 🌐 Seller C (Overseas)        │  │
│  │ EGP 330  •  12 days delivery  │  │
│  │ [Select]                      │  │
│  └───────────────────────────────┘  │
├─────────────────────────────────────┤
│  Home  Search  Library  Profile     │  ← Labelled nav
└─────────────────────────────────────┘
```

**Right Column (Book Detail):**
```
┌─────────────────────────────────────┐
│  ← Back    Book Details             │
├─────────────────────────────────────┤
│  [Cover]  Crime and Punishment      │
│           Dostoyevsky               │
│           ⭐ 4.2  •  430 pages       │
├─────────────────────────────────────┤
│  ⚠  DROP RISK: HIGH                 │
│  You dropped 3 of 4 long, dense     │
│  books. Consider a shorter novel.   │
│  [Dismiss]                          │
├─────────────────────────────────────┤
│  Best price: Seller A · EGP 210     │
│  [Compare all prices] [Add to lib]  │
├─────────────────────────────────────┤
│  Home  Search  Library  Profile     │
└─────────────────────────────────────┘
```

**Key a11y:** Labelled nav, drop risk = icon + text + reason (not colour alone), touch targets ≥56dp.

---

### Slide 27: Nielsen's 10 Heuristics (Layout: `ContentLeft`)
**Title:** Nielsen's 10 Usability Heuristics
**Body (two-column bullet list, bodySmall):**
1. **Visibility of system status** — Keep users informed
2. **Match system & real world** — Familiar language, conventions
3. **User control & freedom** — Emergency exits, undo
4. **Consistency & standards** — Platform conventions, internal consistency
5. **Error prevention** — Prevent errors before they happen
6. **Recognition over recall** — Make options visible
7. **Flexibility & efficiency** — Shortcuts for experts
8. **Aesthetic & minimalist design** — No irrelevant info
9. **Help recognise, diagnose, recover errors** — Plain language, constructive
10. **Help & documentation** — Searchable, task-focused

---

### Slide 28: Three Heuristics Applied (Layout: `TableSlide`)
**Title:** Three Heuristics Applied to Our Wireframes
**Table:**
| Heuristic | v1 Problem (Existing Hi-Fi) | v2 Fix (New Lo-Fi / Planned) |
|-----------|----------------------------|------------------------------|
| **#5 Error Prevention** | Logout icon in bottom nav next to Profile/Settings — easy accidental tap. Sign Out duplicated on Profile. | Removed from bottom nav. Single "Sign Out" on Profile with confirmation modal. |
| **#1 Visibility of System Status** | Progress shown only as "100 / 367" text. No sync indicator. | Progress bar + percentage. "Synced ✓" / "Syncing..." indicator. *(Planned — not yet in hi-fi)* |
| **#6 Recognition over Recall** | Bottom nav icons only (no labels). Theme toggle = sun icon only. | Text labels under every nav icon. Theme toggle shows "Light / Dark" text. *(Shown in v2 lo-fi)* |

**Styling:** Problem rows: errorBg background. Fix rows: successBg background.

---

### Slide 29: Section 7 Header (Layout: `SectionHeader`)
**Section Number:** 07
**Section Title:** Accessibility

---

### Slide 30: Why Accessibility & POUR (Layout: `TwoColumn`)
**Title:** Why Accessibility Matters: POUR
**Left Column:**
- ~15% of world population has a disability
- Accessible design helps everyone (curb cut effect)
- Legal: EAA 2025, ADA, etc.
- Better UX for all users

**Right Column (POUR Table):**
| Principle | Meaning | Shelf Application |
|-----------|---------|-------------------|
| **Perceivable** | Users can see/hear content | 4.5:1 contrast, alt text for covers, scalable text |
| **Operable** | Users can control it | Touch targets ≥48dp, no gesture-only, skip links |
| **Understandable** | Clear, predictable, helpful errors | Plain language, consistent nav, inline validation |
| **Robust** | Works with AT, different devices | Semantic markup, tested with TalkBack/VoiceOver |

---

### Slide 31: Desktop → Mobile Rules (Layout: `TableSlide`)
**Title:** Practical Rules: Desktop Brief → Mobile Reality
**Table:**
| Desktop Rule (Brief) | Mobile Equivalent (Shelf) | Status |
|----------------------|---------------------------|--------|
| Text contrast ≥ 4.5:1 | Text contrast ≥ 4.5:1 (AA) / 7:1 (AAA body) | ✅ Check with tool |
| Full keyboard navigation | Full **touch/AT** navigation: all actions reachable via TalkBack/VoiceOver, logical focus order | ✅ Labelled nav, semantic buttons |
| Never colour alone for meaning | Never colour alone: drop risk uses icon + text + pattern | ✅ v2 book detail |
| Clear labels for every input | Clear labels: Search field has label + placeholder; no icon-only buttons | ✅ v2 screens |

**Speaker Notes:** "We didn't ignore the brief — we translated it. The principles are identical; the implementation differs by platform."

---

### Slide 32: Accessibility Checklist (Layout: `ChecklistSlide`)
**Title:** Accessibility Checklist on Our Wireframes
**Table (with status icons):**
| # | Criterion | Home (v1) | Profile (v1) | Search (v2) | Book Detail (v2) | Action |
|---|-----------|-----------|--------------|-------------|------------------|--------|
| 1 | Text contrast ≥ 4.5:1 (body) | ❌ | ❌ | ✅ | ✅ | Audit with tool |
| 2 | Text contrast ≥ 3:1 (large) | ✅ | ✅ | ✅ | ✅ | Verify |
| 3 | Touch targets ≥ 48×48dp | ❌ | ⚠️ | ✅ | ✅ | Enlarge v1 nav |
| 4 | No colour-only meaning | ⚠️ | ❌ | ✅ | ✅ | Fix v1 streak |
| 5 | Labels on all inputs/buttons | ❌ | ✅ | ✅ | ✅ | Add labels v1 |
| 6 | Focus/traversal order logical | ⚠️ | ⚠️ | ✅ | ✅ | Test with TalkBack |
| 7 | Text resizing (dynamic type) | ⚠️ | ⚠️ | ✅ | ✅ | Test |
| 8 | Screen reader labels | ❌ | ⚠️ | ✅ | ✅ | Add to v1 |
| 9 | Error messages clear & actionable | N/A | N/A | ✅ | ✅ | — |
| 10 | Dark mode support | ✅ | ✅ | ✅ | ✅ | Verify light mode |

**Legend:** ✅ Pass · ⚠️ Partial/Unknown · ❌ Fail · N/A Not applicable

---

### Slide 33: Summary (Layout: `ContentLeft`)
**Title:** Summary & Next Steps
**Body (bulleted, bodySmall):**
- UCD finds problems when they're cheap to fix
- Users, stakeholders, research → who we design for
- Persona & stories → testable requirements
- Problem statement, flow, wireframes → concrete idea
- Heuristics & accessibility checks → better design
- **Next steps:**
  1. Validate persona with real interviews (5+)
  2. Usability-test the wireframes (lo-fi → hi-fi)
  3. Iterate based on findings
  4. Build clickable prototype for stakeholder review

---

### Slide 34: Questions (Layout: `TitleSlide` variant)
**Title:** Questions?
**Subtitle:** Anas Hossam · Youssef Hussein · Hozyfa Batisha
**Footer:** Thank you

---

## Assets to Embed

| Asset | Source | Slides |
|-------|--------|--------|
| `preview.webp` | Project folder | 25 |
| `sdlc-ux-placement.svg` | Render from `diagram-prompts.md` | 6 |
| `stakeholder-map.svg` | Render from `diagram-prompts.md` | 10 |
| `invest-review.svg` | Render from `diagram-prompts.md` | 19 |
| `user-flow.svg` | Render from `diagram-prompts.md` | 22 |
| `heuristics-applied.svg` | Render from `diagram-prompts.md` | 28 |
| `cost-curve.svg` | Render from `diagram-prompts.md` (optional) | 4 |

**Rendering instruction:** Use Mermaid CLI (`mmdc`) with dark theme config. Export as SVG with transparent background.

---

## Speaker Notes

**Include speaker notes on every slide** (from `presentation-study-guide.md` "Presenter Scripts" section). These are critical for rehearsal.

---

## Quality Checklist (Run Before Delivering)

- [ ] All 34 slides created
- [ ] Dark theme applied consistently (no white backgrounds)
- [ ] Primary colour #E8DCCC used for accents, not primary text
- [ ] Typography scale respected (no random sizes)
- [ ] All diagrams rendered as crisp SVGs (not rasterised)
- [ ] `preview.webp` embedded at high quality (not compressed)
- [ ] Tables styled: header=primary bg, alternating rows, textPrimary
- [ ] Code blocks: monospace, surface bg, primary text, proper wrapping
- [ ] Status icons (✅ ⚠️ ❌) render correctly in PPTX
- [ ] Speaker notes present on every slide
- [ ] Slide numbers hidden (clean presentation mode)
- [ ] File size < 50 MB
- [ ] Opens correctly in PowerPoint (not just LibreOffice/Keynote)

---

## Alternative: Marp Markdown Output

If generating Marp/Markdown instead of python-pptx, use this frontmatter:

```yaml
---
marp: true
theme: shelf-dark
paginate: true
size: 16:9
style: |
  @import url('https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700&display=swap');
  :root {
    --bg: #0D0D0D;
    --surface: #1A1A1A;
    --primary: #E8DCCC;
    --text: #F5F0E8;
    --text-dim: #A89E90;
    --error: #CC4444;
    --success: #44CC44;
    --warning: #CCAA44;
  }
  section { background: var(--bg); color: var(--text); font-family: 'Inter', system-ui; padding: 64px 96px; }
  h1 { font-size: 44px; font-weight: 700; color: var(--primary); margin-bottom: 24px; }
  h2 { font-size: 32px; font-weight: 600; margin-bottom: 16px; }
  h3 { font-size: 24px; font-weight: 600; color: var(--primary); }
  p, li { font-size: 18px; line-height: 1.6; color: var(--text); }
  .small { font-size: 16px; line-height: 1.5; }
  .caption { font-size: 14px; color: var(--text-dim); }
  table { font-size: 14px; border-collapse: collapse; width: 100%; }
  th { background: var(--primary); color: var(--bg); font-weight: 600; padding: 12px; }
  td { border: 1px solid #2A2A2A; padding: 12px; }
  tr:nth-child(even) td { background: var(--surface); }
  code { background: var(--surface); padding: 2px 6px; border-radius: 4px; font-size: 14px; }
  pre { background: var(--surface); padding: 16px; border-radius: 12px; overflow: auto; }
  pre code { background: none; padding: 0; font-size: 14px; line-height: 1.6; }
  .overline { font-size: 12px; font-weight: 600; letter-spacing: 1px; text-transform: uppercase; color: var(--primary); margin-bottom: 8px; }
  .two-col { display: grid; grid-template-columns: 1fr 1fr; gap: 32px; }
  .status-pass { color: var(--success); }
  .status-warn { color: var(--warning); }
  .status-fail { color: var(--error); }
  .card { background: var(--surface); border-radius: 12px; padding: 24px; }
  img { max-width: 100%; border-radius: 8px; }
---
```

Then each slide = `---` separated markdown with the content above.

---

## Final Instruction to Generating Model

> **Generate a complete, polished `.pptx` file** using python-pptx (or Marp CLI → pandoc → pptx). Do not output code — output the binary `.pptx` file or a base64-encoded string I can save. Use the exact content, styling, and assets specified above. Speaker notes must be included. Diagrams must be rendered as SVGs from the Mermaid source in `diagram-prompts.md` and embedded. The `preview.webp` image is in the project folder. The output file should be named `Shelf_UCD_Presentation_FINAL.pptx`.

---

## File Structure for Reference

```
/shelf-ucd-presentation/
├── content.md                    # All text content
├── diagram-prompts.md            # Mermaid source + regeneration prompts
├── wireframe-prompts.md          # AI prompts for new wireframes
├── presentation-study-guide.md   # This team's study guide
├── deck-generation-prompt.md     # THIS FILE
├── preview.webp                  # Existing v1 screens
└── (generated diagrams as SVG)   # Run mmdc to create
```

**Run this to generate diagrams:**
```bash
cd /home/Anas/vibing/pi/shelf-ucd-presentation
npx -y @mermaid-js/mermaid-cli -i diagram-prompts.md -o ./diagrams/ -b transparent --theme dark
# Or use mermaid.live manually
```