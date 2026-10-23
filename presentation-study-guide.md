# Shelf — UCD Presentation Study Guide

**App:** Shelf | **Team:** Anas Hossam, Youssef Hussein, Hozyfa Batisha
**Date:** Sunday deadline | **Duration:** 60 min | **Format:** PowerPoint, dark theme
**Presenter Rotation:** Anas (Sec 1, 4, 7) · Youssef (Sec 2, 5) · Hozyfa (Sec 3, 6)

---

## 1. Slide Index & Time Plan

| # | Slide Title | Section | Presenter | Min | Cumulative | Skip if Short |
|---|-------------|---------|-----------|-----|------------|---------------|
| 1 | Title: Shelf — UCD for Book Comparison & Reading Tracker | — | Anas | 0:30 | 0:30 | — |
| 2 | Why User-Centred Design? | 1 | Anas | 1:30 | 2:00 | — |
| 3 | Cost of Fixing Errors Curve | 1 | Anas | 1:30 | 3:30 | — |
| 4 | Usability: ISO 9241-11 | 1 | Anas | 1:30 | 5:00 | — |
| 5 | Where UX Sits in the SDLC | 1 | Anas | 1:30 | 6:30 | — |
| 6 | Users vs Stakeholders | 2 | Youssef | 1:30 | 8:00 | — |
| 7 | User Research Methods | 2 | Youssef | 1:30 | 9:30 | — |
| 8 | Stakeholder Map (Power/Interest) | 2 | Youssef | 1:30 | 11:00 | — |
| 9 | What is a Persona? | 3 | Hozyfa | 1:00 | 12:00 | — |
| 10 | Proto-Persona: Layla Hassan | 3 | Hozyfa | 2:00 | 14:00 | — |
| 11 | User Story Format & INVEST | 4 | Anas | 1:30 | 15:30 | — |
| 12 | Story 1: Compare Prices | 4 | Anas | 1:30 | 17:00 | — |
| 13 | Story 2: Synced Progress | 4 | Anas | 1:30 | 18:30 | — |
| 14 | Story 3: Drop Warning | 4 | Anas | 1:30 | 20:00 | — |
| 15 | INVECT Review (Self-Critique) | 4 | Anas | 1:30 | 21:30 | ⚠️ |
| 16 | Problem Statement | 5 | Youssef | 1:30 | 23:00 | — |
| 17 | User Flow: Find & Buy a Book | 5 | Youssef | 2:00 | 25:00 | — |
| 18 | Low vs High Fidelity | 6 | Hozyfa | 1:00 | 26:00 | — |
| 19 | Existing Hi-Fi Screens (v1) | 6 | Hozyfa | 1:30 | 27:30 | — |
| 20 | New Lo-Fi Screens (v2): Search & Book Detail | 6 | Hozyfa | 2:00 | 29:30 | — |
| 21 | Nielsen's 10 Heuristics | 6 | Hozyfa | 1:00 | 30:30 | ⚠️ |
| 22 | Three Heuristics Applied | 6 | Hozyfa | 2:00 | 32:30 | — |
| 23 | Why Accessibility: POUR | 7 | Anas | 1:30 | 34:00 | — |
| 24 | Desktop→Mobile Rules Mapping | 7 | Anas | 1:30 | 35:30 | — |
| 25 | Accessibility Checklist on Wireframes | 7 | Anas | 2:00 | 37:30 | — |
| 26 | Summary & Next Steps | — | Anas | 1:00 | 38:30 | — |
| 27 | Questions | — | All | 2:00 | 40:30 | — |
| — | **Buffer / Deep Dive / Prof Q&A** | — | — | **19:30** | **60:00** | — |

> **Total content: ~40 min. Buffer: ~20 min for questions, transitions, and prof interruptions.**

---

## 2. Presenter Scripts (Per Slide)

### Slide 1 — Title
**Anas (0:30)**
- "Shelf — a book price comparison and reading tracker app. We'll walk through the full UCD process: research, personas, stories, flows, wireframes, heuristics, accessibility."
- "Team: Anas, Youssef, Hozyfa. I'm presenting sections 1, 4, and 7."

---

### Slide 2 — Why User-Centred Design?
**Anas (1:30)**
- "UCD means designing around real users' goals, tasks, and context — and validating with them at every stage."
- "It's not about aesthetics. It's about building the *right* thing before building the thing right."
- "ISO 9241-210 defines the process: understand context → specify requirements → design solutions → evaluate against requirements."

---

### Slide 3 — Cost of Fixing Errors Curve
**Anas (1:30)**
- "A requirement error caught in requirements costs 1×. In design: 3–6×. In code: 10–15×. In testing: 30–50×. After release: ~100×."
- "Shelf example: If we integrate 6 bookstore APIs assuming users want *all prices*, but they only want *the cheapest local offer*, finding this after launch means rewriting aggregation, renegotiating APIs, losing trust. On paper: a sticky note."
- "Exact multipliers are debated (Boehm, NASA, McConnell). The *trend* is not. We show the curve, not the numbers."

---

### Slide 4 — Usability: ISO 9241-11
**Anas (1:30)**
- "Usability = effectiveness, efficiency, satisfaction in a specified context of use."
- "Effectiveness: Can they complete the goal? Shelf: find a book, see cheapest local offer."
- "Efficiency: Effort/time/taps. Shelf: result in ≤3 taps, progress logged without typing."
- "Satisfaction: Comfortable, trustworthy. Shelf: honest drop warnings, no pushy recommendations."
- "Context of use is the most overlooked: who (readers), what (comparing/tracking), where (metro, bed, bookstore), on what (phone)."

---

### Slide 5 — Where UX Sits in the SDLC
**Anas (1:30)**
- "UX is not a phase. It's a thread: before design (research, personas), during testing (usability tests with real tasks), after release (feedback → next iteration)."
- "Research & Requirements: interviews, surveys, stakeholder map, problem statement."
- "Design & Prototype: flows, lo-fi wireframes, heuristic eval, prototype testing."
- "Implementation: design handoff, accessibility annotations, dev Q&A."
- "Test & Evaluate: usability testing, analytics review."
- "Release & Feedback: app store reviews, support tickets, analytics → next iteration."

---

### Slide 6 — Users vs Stakeholders
**Youssef (1:30)**
- "Primary users: readers who search, compare, log progress daily."
- "Secondary users: gift buyers, friends sharing lists, support staff."
- "Stakeholders: bookstores (visibility), marketplaces (API terms), app stores (guidelines), dev team, instructor, authors/publishers, payment partners."
- "Key: every stakeholder has a goal. Our job is balancing them without harming the primary user."

---

### Slide 7 — User Research Methods
**Youssef (1:30)**
- "Three methods, triangulated:"
- "Interviews: deep context, 'why', follow-up. Limits: small sample, bias. Shelf: 5–8 readers, 'walk me through last book purchase'."
- "Questionnaires: larger sample, quantifiable. Limits: no follow-up, self-report bias. Shelf: 20+ readers on frequency, pain points, price sensitivity, drop reasons."
- "Observation: real behaviour, context visible. Limits: observer effect, no 'why'. Shelf: watch 3 users compare prices across tabs (screen-record, consent)."
- "Use at least two. Interviews + questionnaires = depth + breadth."

---

### Slide 8 — Stakeholder Map
**Youssef (1:30)**
- "Power/Interest grid. Four quadrants:"
- "Manage Closely (High/High): Dev team, Instructor — frequent comms, involve in decisions."
- "Keep Satisfied (High/Low): Marketplaces, App stores — meet requirements, monitor policy."
- "Keep Informed (Low/High): Readers, Local bookstores, Authors — regular updates, feedback channels."
- "Monitor (Low/Low): Review sites, Affiliate partners — periodic check."

---

### Slide 9 — What is a Persona?
**Hozyfa (1:00)**
- "Fictional but realistic archetype from research data. Not a stereotype."
- "Contains: name, photo, age, role, goals, frustrations, tech skills, context, quote."
- "Golden rule: evidence-based. Invented personas create false confidence."

---

### Slide 10 — Proto-Persona: Layla Hassan
**Hozyfa (2:00)**
- "This is a *proto-persona* — built from team experience and informal chats. Next step: validate with 5+ interviews."
- "Layla, 21, Cairo student. Reads EN/AR. 1–2 books/month on student budget. Phone-first, commute + bed."
- "Goals: lowest local price, keep reading habit, pick books she'll finish."
- "Frustrations: comparing across tabs, losing place across devices, paying for abandoned books."
- "Quote: 'I just want to know: where's the cheapest copy near me, and will I actually finish this one?'"
- "Each goal/frustration maps to a research question in our questionnaire."

---

### Slide 11 — User Story Format & INVEST
**Anas (1:30)**
- "Format: As a <role>, I want <goal>, so that <benefit>."
- "INVEST: Independent, Negotiable, Valuable, Estimable, Small, Testable."
- "We'll show three stories, then honestly critique them against INVEST."

---

### Slide 12 — Story 1: Compare Prices
**Anas (1:30)**
- "As a reader, I want to search a title and see local sellers first sorted by price, so I can buy cheaply and quickly."
- "AC1: Given I'm in country X and search 'Crime and Punishment', When results load, Then local sellers appear first, sorted by price ascending, each showing price, delivery, seller name."
- "AC2: Given no local seller has it, When results load, Then overseas sellers appear with 'Overseas' label, delivery estimate, total cost."
- "AC3: Given search fails, When error occurs, Then clear message: 'Couldn't reach sellers. Check connection or try again.' with retry."

---

### Slide 13 — Story 2: Synced Progress
**Anas (1:30)**
- "As a reader, I want my progress synced across devices, so I can continue where I stopped on any device."
- "AC1: Given I read to page 100 on phone, When I open on tablet, Then it shows page 100 within 5 seconds with 'Synced' indicator."
- "AC2: Given I'm offline, When I read 20 pages, Then progress saved locally and synced on reconnect."
- "AC3: Given I read on two devices offline, When both reconnect, Then last-write-wins with toast 'Progress merged from [device]'."

---

### Slide 14 — Story 3: Drop Warning
**Anas (1:30)**
- "As a reader, I want a warning when a book is likely to be dropped, so I don't waste money on it."
- "AC1: Given 5+ books in history, When I open book detail, Then I see drop-risk level (Low/Med/High) with one-line reason."
- "AC2: Given <5 books, When I open book detail, Then 'Not enough history yet — add more books to see drop risk.'"
- "AC3: Given High risk, When I tap 'Add to library', Then confirmation modal: 'This book has high drop risk for you. Add anyway?' [Cancel] [Add]."

---

### Slide 15 — INVECT Review (Self-Critique)
**Anas (1:30)**
- "Story 1: passes all six. Estimable if country scope fixed. Small if one country per sprint."
- "Story 2: passes I,N,V,S,T. Estimable risk: sync conflicts need a rule before sizing."
- "Story 3: fails Independent (depends on Story 2 history). Fix: split into 'collect history' + 'show warning'."
- "This honesty shows we understand INVEST. Stories are conversation starters; acceptance criteria turn them into tests."

---

### Slide 16 — Problem Statement
**Youssef (1:30)**
- "118 words. Structure: Who → What → Why."
- "Who: Readers, especially students/budget-conscious."
- "What: Fragmented price comparison + no drop prediction + no unified tracking."
- "Why: Wasted money, broken habits, time lost."
- "Read it aloud. It's in the deck."

---

### Slide 17 — User Flow: Find & Buy a Book
**Youssef (2:00)**
- "Happy path (6 steps): Open app → Search → Results (local first) → Book detail (drop risk, best price) → Tap seller → External purchase → Add to library."
- "Error path 1 (no results/network): Inline message with Retry / Search Author / Browse Categories — all loop back."
- "Error path 2 (seller link fails): Toast 'Couldn't open seller. Copy link?' Copy / Dismiss."
- "No dead ends. Every error has a recovery action."

---

### Slide 18 — Low vs High Fidelity
**Hozyfa (1:00)**
- "Lo-fi: boxes, labels, no colour. Fast, cheap. Use early for layout, flow, IA, structure testing."
- "Hi-fi: colours, type, images, spacing. Use later for visual hierarchy, contrast, details, dev handoff."
- "Our approach: lo-fi for new screens (search, book detail). Keep existing hi-fi (home, profile) as v1 baseline, show v2 improvements."

---

### Slide 19 — Existing Hi-Fi Screens (v1)
**Hozyfa (1:30)**
- "Home: Continue reading card (progress text only, no bar), 'Read a New Book' (recs, no why), bottom nav icon-only, theme toggle sun icon only."
- "Profile: Stats with grammar issues ('12 Book', '3284 Page', '47 hour'), streak visual, Sign Out duplicated (nav + profile), dark theme for night reading."
- "Gaps: No price comparison, no drop warning, no search results, no book detail with sellers."

---

### Slide 20 — New Lo-Fi Screens (v2)
**Hozyfa (2:00)**
- "Search Results: Local first (price ↑), then Overseas. Each card: seller, price, delivery, Select. Labelled bottom nav."
- "Book Detail: Cover, metadata, **Drop Risk warning** (icon + text + reason, NOT colour alone), best price, Compare / Add to library. High risk → confirmation modal."
- "Key a11y: labelled nav, drop risk uses icon+text+word, touch targets ≥56dp."

---

### Slide 21 — Nielsen's 10 Heuristics
**Hozyfa (1:00)**
- "Quick reference. We applied three to our wireframes:"
- "1. Visibility of system status | 2. Match system/real world | 3. User control/freedom | 4. Consistency | 5. Error prevention | 6. Recognition over recall | 7. Flexibility/efficiency | 8. Aesthetic/minimalist | 9. Help recognise/diagnose/recover errors | 10. Help/docs"

---

### Slide 22 — Three Heuristics Applied
**Hozyfa (2:00)**
- "#5 Error Prevention: v1 logout icon in bottom nav next to Profile/Settings (easy accidental tap), duplicated on Profile. v2: removed from nav, single Sign Out on Profile with confirmation."
- "#1 Visibility of Status: v1 progress only '100/367' text, no sync indicator. v2: progress bar + percentage, 'Synced ✓' / 'Syncing...' indicator. (Planned — not yet in hi-fi)"
- "#6 Recognition over Recall: v1 nav icons only, theme toggle sun icon only. v2: text labels under every nav icon, theme toggle shows 'Light/Dark' text. (Shown in v2 lo-fi)"

---

### Slide 23 — Why Accessibility: POUR
**Anas (1:30)**
- "~15% world population has disability. Accessible design helps everyone (curb cut effect). Legal: EAA 2025, ADA."
- "POUR: Perceivable (contrast, alt text, scalable text), Operable (touch targets, no gesture-only, skip links), Understandable (plain language, predictable, helpful errors), Robust (semantic markup, TalkBack/VoiceOver tested)."

---

### Slide 24 — Desktop→Mobile Rules Mapping
**Anas (1:30)**
- "Brief asks for desktop rules. We translate honestly:"
- "Contrast ≥4.5:1 → same on mobile (AA/AAA)."
- "Keyboard nav → Touch nav: all actions reachable via TalkBack/VoiceOver, logical focus order."
- "Never colour alone → Drop risk uses icon + text + pattern."
- "Clear labels → Search field has label + placeholder; no icon-only buttons."
- "We didn't ignore the brief — we translated. Principles identical; implementation differs by platform."

---

### Slide 25 — Accessibility Checklist
**Anas (2:00)**
- "10 criteria across 4 screens. Key findings:"
- "v1 Home/Profile: contrast likely fails (grey on dark), nav icons unlabelled, touch targets small, streak colour-only."
- "v2 Search/Book Detail: designed for contrast, labelled, 56dp targets, drop risk icon+text."
- "Action items: audit v1 with tool, enlarge nav targets, add screen reader labels, test with TalkBack/VoiceOver."
- "We're honest: v1 has gaps, v2 fixes them."

---

### Slide 26 — Summary & Next Steps
**Anas (1:00)**
- "UCD finds problems when cheap to fix."
- "Users, stakeholders, research → who we design for."
- "Persona + stories → testable requirements."
- "Problem statement, flow, wireframes → concrete idea."
- "Heuristics + accessibility → better design."
- "Next: validate persona with real interviews. Usability-test wireframes. Iterate."

---

### Slide 27 — Questions
**All (2:00)**
- Field questions together. Defer to relevant presenter.

---

## 3. Anticipated Prof Questions & Model Answers

### Section 1: UCD Theory

| Question | Model Answer |
|----------|--------------|
| "Why do you cite 100× if it's disputed?" | "We explicitly say exact multipliers are debated. The *trend* — exponential rise — is undisputed across Boehm, NASA, McConnell. We show the curve, not the numbers." |
| "Where exactly does UX happen in *your* SDLC?" | "Before design: we did research, personas, problem statement. During design: flows, lo-fi wireframes, heuristic eval. During test: we'd run usability tests with real tasks. After release: analytics → next sprint. It's continuous." |
| "Is ISO 9241-11 the only usability definition?" | "It's the international standard. Others exist (Nielsen, Shackel), but ISO is the baseline for 'effectiveness, efficiency, satisfaction in context of use'." |

### Section 2: Users, Stakeholders, Research

| Question | Model Answer |
|----------|--------------|
| "Did you actually interview 8 people?" | "We built a proto-persona from team experience and informal chats. We designed a questionnaire and interview guide (in appendix). Validation is the stated next step. We're transparent about evidence status." |
| "Why is 'Readers' low power in the stakeholder map?" | "Power = ability to influence the project. Readers don't control budget, API access, or grading. But they're *high interest* — we keep them informed and test with them. Power/Interest maps influence strategy, not importance." |
| "Couldn't local bookstores be high power?" | "In some markets yes. For Shelf, they don't control API access or app store approval. We'd move them if evidence showed otherwise." |

### Section 3: Persona

| Question | Model Answer |
|----------|--------------|
| "This persona isn't from real data. Isn't that against the brief?" | "The brief says personas must be based on evidence, not stereotypes. We label this a *proto-persona* explicitly, state its source (team experience + informal chats), and name validation with 5+ interviews as the immediate next step. That *is* following the brief — it's honest about evidence status." |
| "Why only one persona?" | "One primary persona (Layla) covers the core user. Secondary personas (gift buyer, power reader) are in appendix. Time-boxed for presentation." |

### Section 4: User Stories

| Question | Model Answer |
|----------|--------------|
| "Story 3 fails Independent. Why present it?" | "We present it *with the critique*. Acknowledging INVEST failures shows we understand the criteria. The fix (split into 'collect history' + 'show warning') is on the slide." |
| "Are these stories too big for a sprint?" | "Story 1 needs country scoping. Story 2 needs sync conflict rule. We flagged both. In practice they'd be broken down further." |
| "Why Given/When/Then instead of a checklist?" | "GWT makes acceptance criteria executable. Each maps to a test case. Checklist items are ambiguous." |

### Section 5: Problem Statement & Flow

| Question | Model Answer |
|----------|--------------|
| "Is the problem statement exactly 100–150 words?" | "118 words. Counted." |
| "Why does the error path loop back to Search instead of Home?" | "User's intent is still to find a book. Home loses context. Retry/Search Author/Browse keep them in the task." |
| "What if the seller deep link fails *after* purchase?" | "That's a post-purchase flow (order confirmation, receipt). Out of scope for this flow. We'd handle it in 'Order History'." |

### Section 6: Wireframes & Heuristics

| Question | Model Answer |
|----------|--------------|
| "You only have 2 hi-fi screens. The brief asks for 3+ wireframes." | "We have 2 existing hi-fi (home, profile) + 2 new lo-fi (search results, book detail) = 4 screens covering the core value. The new screens are lo-fi because they're earlier in the process — which is *correct* UCD practice." |
| "You claim heuristic fixes on v2 but v2 is lo-fi. Where's the hi-fi proof?" | "v2 lo-fi shows the structural fixes (labelled nav, drop-risk card structure). Visual polish (progress bar, sync indicator) is planned for hi-fi v2. We're transparent: 'planned — not yet drawn in hi-fi'." |
| "Why didn't you apply all 10 heuristics?" | "Time-boxed. We applied 3 that had clear v1→v2 evidence. The other 7 are in appendix with pass/fail notes." |

### Section 7: Accessibility

| Question | Model Answer |
|----------|--------------|
| "The brief asks for desktop rules. You made a mobile app." | "We mapped each desktop rule to its mobile equivalent on Slide 24. Principles (POUR) are identical; implementation differs. Contrast ≥4.5:1 applies to both. Keyboard → touch/AT. Colour-only → icon+text. Labels → same. We didn't dodge — we translated." |
| "Have you tested with TalkBack/VoiceOver?" | "Not yet — it's a wireframe stage. The checklist marks 'Unknown' where testing is needed. Next step: test v2 lo-fi prototype with screen readers." |
| "Does the dark theme meet contrast?" | "We designed for it (beige #E8DCCC on #0D0D0D = 12.8:1). But we flag 'verify with tool' on the checklist. We don't assume." |

### Curveballs

| Question | Model Answer |
|----------|--------------|
| "Why a mobile app in a C# course?" | "The assignment is UCD process, not implementation. The platform doesn't change the method. A desktop port would follow the same POUR principles with keyboard-first navigation." |
| "How does the drop-risk algorithm work?" | "It's a UX presentation, not ML. The *design* shows the warning with a reason ('You dropped 3 of 4 long, dense books'). The algorithm is a separate technical challenge." |
| "Who pays for the API calls to 6 bookstores?" | "Affiliate revenue / referral fees. Not in UX scope, but acknowledged in stakeholder map (payment partners = Monitor)." |
| "What if a user is in a country with no local sellers?" | "Flow handles it: overseas section appears with clear 'Overseas' label, delivery estimate, total cost. No empty dead end." |

---

## 4. "If Asked X, Say Y" — Quick Cheat Sheet

| Trigger Phrase | Your Response |
|----------------|---------------|
| "100× is fake" | "We say exact numbers are debated. The exponential trend is not." |
| "Proto-persona = fake" | "Proto-persona = evidence from team + informal chats, labeled as such, validation plan stated. That's honest UCD." |
| "Only 2 hi-fi screens" | "2 existing hi-fi + 2 new lo-fi = 4 screens. Lo-fi for new screens is *correct* — you don't polish untested flows." |
| "Mobile vs desktop rules" | "We mapped them explicitly. POUR is platform-agnostic." |
| "Story 3 fails Independent" | "We flagged it. Fix: split story. Honest critique > fake pass." |
| "No real user testing" | "Next step. Checklist marks 'Unknown' where testing needed. We designed *for* testability." |
| "Grammar in v1 stats" | "Fixed in v2: '12 books', '3,284 pages', '47 hours'. v1 is the 'before' baseline." |
| "Sign Out duplicated" | "Fixed in v2: removed from bottom nav, single destructive action on Profile with confirmation." |

---

## 5. Evidence Traceability Matrix

| Claim | Source | Slide |
|-------|--------|-------|
| "Cost rises exponentially" | Boehm 1981, NASA 1990, McConnell 1996 | 3 |
| "ISO 9241-11 definition" | ISO standard | 4 |
| "UX before design, during test, after release" | ISO 9241-210 | 5 |
| "Primary/secondary/stakeholder distinction" | UCD literature | 6 |
| "Interview/questionnaire/observation strengths/limits" | Research methods textbooks | 7 |
| "Power/Interest grid" | Mendelow 1991 | 8 |
| "Persona = evidence-based" | Cooper 1999, ISO 9241-210 | 9 |
| "Layla's goals/frustrations" | Team experience + informal chats (proto) | 10 |
| "INVEST criteria" | Wake 2003 | 11 |
| "Story 1 ACs" | Derived from problem statement | 12 |
| "Story 2 ACs" | Derived from problem statement | 13 |
| "Story 3 ACs" | Derived from problem statement | 14 |
| "INVEST review results" | Team analysis | 15 |
| "Problem statement (118 words)" | Team synthesis | 16 |
| "User flow happy/error paths" | Task analysis | 17 |
| "Lo-fi vs hi-fi definitions" | UX practice | 18 |
| "v1 screen gaps" | Heuristic evaluation of preview.webp | 19 |
| "v2 screen designs" | New design work | 20 |
| "Nielsen's 10" | Nielsen 1994 | 21 |
| "3 heuristics applied" | Heuristic evaluation of v1 vs v2 | 22 |
| "POUR principles" | WCAG 2.1 | 23 |
| "Desktop→mobile mapping" | Team translation | 24 |
| "Checklist results" | Manual audit of 4 screens | 25 |

---

## 6. Timekeeper Notes (for Anas — you're first and last)

| Milestone | Target Time | Action if Behind |
|-----------|-------------|------------------|
| End of Section 1 (Slide 5) | 6:30 | Cut ISO 9241-11 examples to 30s |
| End of Section 2 (Slide 8) | 11:00 | Combine research methods + stakeholder map |
| End of Section 3 (Slide 10) | 14:00 | Shorten persona intro |
| End of Section 4 (Slide 15) | 21:30 | **Skip INVEST review slide** if needed — it's self-critique |
| End of Section 5 (Slide 17) | 25:00 | Read problem statement faster, flow diagram speaks for itself |
| End of Section 6 (Slide 22) | 32:30 | Skip Nielsen's 10 list (slide 21) — go straight to applied |
| End of Section 7 (Slide 25) | 37:30 | Highlight only top 3 checklist fails |
| Summary + Questions | 40:30 | — |

**Red flag:** If you're past Slide 10 at 15:00, skip INVEST review (slide 15) and Nielsen's 10 list (slide 21). Those are the only skippable slides.

---

## 7. Presenter Handoff Cues

| From → To | Slide | Cue Line |
|-----------|-------|----------|
| Anas → Youssef | 5→6 | "Youssef will now cover who we're designing for — users, stakeholders, and how we research them." |
| Youssef → Hozyfa | 8→9 | "Hozyfa takes over for personas — turning research into a concrete archetype." |
| Hozyfa → Anas | 10→11 | "Anas returns for user stories — making the persona testable." |
| Anas → Youssef | 15→16 | "Youssef walks through the problem statement and the user flow." |
| Youssef → Hozyfa | 17→18 | "Hozyfa shows the wireframes — from lo-fi to hi-fi, and what heuristics reveal." |
| Hozyfa → Anas | 22→23 | "Anas closes with accessibility — POUR, mobile rules, and our checklist." |
| Anas → All | 26→27 | "We're happy to take questions." |

---

## 8. Appendix References (Not Presented, But Ready)

- Full questionnaire (12 questions)
- Interview guide (8 questions)
- Secondary personas (Gift Buyer, Power Reader)
- All 10 heuristics pass/fail table
- Contrast audit screenshots (to generate)
- TalkBack/VoiceOver test script
- Figma file link (view access)

---

**Print this. Keep it open on a second device. You've got this.**