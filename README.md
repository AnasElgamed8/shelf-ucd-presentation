# Shelf UCD Presentation — Project Index

**Location:** `/home/Anas/vibing/pi/shelf-ucd-presentation/`

---

## Files Created

| File | Purpose | For Whom |
|------|---------|----------|
| `content.md` | All 7 sections' text, tables, diagrams (Mermaid), speaker notes | **Everyone** — source of truth for slide content |
| `diagram-prompts.md` | 6 Mermaid diagrams + regeneration prompts for each | **Hozyfa / diagram maker** — render as SVG for slides |
| `wireframe-prompts.md` | Detailed AI prompts for 5 screens (Search, Book Detail, Home v2, Profile v2, Onboarding) | **Hozyfa / wireframe maker** — Figma, v0.dev, Galileo, etc. |
| `presentation-study-guide.md` | Slide index, presenter scripts, anticipated Q&A, cheat sheet, evidence matrix | **All 3 presenters** — print or second-screen for rehearsal |
| `deck-generation-prompt.md` | Complete spec for generating the final `.pptx` (design system, 34 slides, assets, QC) | **Send to another AI** (GPT-4o, Claude, Gemini) to produce the actual PowerPoint |
| `preview.webp` | Your existing v1 hi-fi screens (Home + Profile) | **Embed in slides 25** |

---

## Quick Start for Teammates

### Anas (Sections 1, 4, 7)
1. Read `presentation-study-guide.md` → **Slides 2–6, 15–19, 30–33**
2. Practice your ~24 minutes of content
3. Own the Q&A cheat sheet (Section 4 of study guide)

### Youssef (Sections 2, 5)
1. Read `presentation-study-guide.md` → **Slides 7–10, 21–22**
2. Practice your ~16 minutes
3. Be ready to defend stakeholder map + problem statement word count

### Hozyfa (Sections 3, 6)
1. Read `presentation-study-guide.md` → **Slides 11–14, 24–28**
2. **Generate wireframes** using `wireframe-prompts.md` (priority: Search Results + Book Detail)
3. **Render diagrams** from `diagram-prompts.md` as SVGs:
   ```bash
   # If you have Node:
   npx -y @mermaid-js/mermaid-cli -i diagram-prompts.md -o ./diagrams/ -b transparent --theme dark
   # Or paste each Mermaid block into https://mermaid.live/ → Export SVG
   ```
4. Embed `preview.webp` + new wireframes + SVGs into the deck

---

## Generating the Final PowerPoint

**Option A: Send to another AI (Recommended)**
```
Upload deck-generation-prompt.md + content.md + diagram-prompts.md + preview.webp
to GPT-4o / Claude 3.5 Sonnet / Gemini 2.5 Pro
Prompt: "Generate the .pptx file per deck-generation-prompt.md"
```

**Option B: Build locally with python-pptx**
```bash
cd /home/Anas/vibing/pi/shelf-ucd-presentation
python3 -m venv venv && source venv/bin/activate
pip install python-pptx
# Write a script using the spec in deck-generation-prompt.md
```

**Option C: Marp → Pandoc → PPTX**
```bash
# Install Marp CLI
npm install -g @marp-team/marp-cli
# Convert the markdown (you'd need to convert content.md to Marp format first)
marp content.md --allow-local-files --output presentation.pdf
# Then use pandoc for PPTX if needed
```

---

## Diagram Rendering Checklist

| Diagram | Mermaid Source | Output SVG | Slides |
|---------|----------------|------------|--------|
| SDLC UX Placement | `sdlc-ux-placement.mmd` | `sdlc-ux-placement.svg` | 6 |
| Stakeholder Map | `stakeholder-map.mmd` | `stakeholder-map.svg` | 10 |
| INVEST Review | `invest-review.mmd` | `invest-review.svg` | 19 |
| User Flow | `user-flow.mmd` | `user-flow.svg` | 22 |
| Heuristics Applied | `heuristics-applied.mmd` | `heuristics-applied.svg` | 28 |
| Cost Curve (optional) | `cost-curve.mmd` | `cost-curve.svg` | 4 |

**Dark theme config for mermaid.live:**
```css
:root {
  --mermaid-background: #0D0D0D;
  --mermaid-main-0: #F5F0E8;
  --mermaid-main-1: #E8DCCC;
  --mermaid-accent-0: #E8DCCC;
}
```

---

## Wireframe Priority Order

1. **Search Results (Hi-Fi)** — Core value: price comparison, local first
2. **Book Detail (Hi-Fi)** — Core differentiator: drop-risk warning
3. **Home v2 (Hi-Fi)** — Fixes: labelled nav, progress bar, sync indicator
4. **Profile v2 (Hi-Fi)** — Fixes: grammar, single Sign Out, sync status
5. **Onboarding (3 screens)** — Nice to have for "wow" factor

**Tools:** Figma (manual), v0.dev, Galileo AI, Uizard, Magic Patterns, or hand-sketch → photo

---

## Sunday Deadline Timeline (Today)

| Time | Activity |
|------|----------|
| **Now** | Hozyfa starts wireframes (Search + Book Detail) |
| **+1 hr** | Diagrams rendered as SVGs |
| **+2 hr** | Deck generated via AI (send prompt) |
| **+3 hr** | Review deck, fix issues, embed wireframes |
| **+4 hr** | Each presenter rehearses with study guide (2× each) |
| **+5 hr** | Final polish, export, backup |

---

## Backup Plan

If AI deck generation fails:
1. Use `content.md` + `deck-generation-prompt.md` to build manually in PowerPoint (2–3 hours)
2. Apply design system from prompt
3. Copy-paste content, insert SVGs + `preview.webp`
4. Add speaker notes from `presentation-study-guide.md`

---

## Contact

**Anas Hossam** — Lead presenter, deck owner
**Youssef Hussein** — Sections 2, 5
**Hozyfa Batisha** — Sections 3, 6, wireframes, diagrams

**All files in:** `/home/Anas/vibing/pi/shelf-ucd-presentation/`