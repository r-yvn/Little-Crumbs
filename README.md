# 🥐 Little Crumbs - Boutique Artisan Bakery Web Portal

> A Blazor Web App (.NET 8, Interactive Server) styled with Tailwind CSS v4. Browse a bakery recipe cookbook, search by title, filter by category, and tick off ingredients as you bake, all in a warm cream-and-chocolate theme.

---

## ✨ Features

- **Artisan bakery theme:** Warm cream (`#F7F4EE`) and deep chocolate (`#4A2E1B`) palette, serif headings, uniform square image cards, and styled links that override the browser's default blue.
- **Recipe catalog:** A card grid with image, category badge, prep time, rating, and a "Start Baking" link to each recipe.
- **Live title search:** The catalog filters as you type, matching against recipe titles only.
- **Category filtering:** Filter by All, Cakes, Pastries, or Cookies. The home page category cards deep-link into the catalog with a `?category=` query string.
- **Recipe detail pages:** Prep, bake, and serving info, ratings, an ingredient list, and numbered baking instructions.
- **Interactive ingredient checklist:** Tick off ingredients as you go (state is kept for the current session).
- **Friendly empty states:** A "No sweet treats found" panel with a Reset Filters button, and a "Recipe not found" page for unknown IDs.
- **Navigation:** Sticky header with logo, Home, Our Story, and Browse Recipes links, plus a "Back to Cookbook" button on recipe pages.

---

## 🛠️ Tech Stack

| Layer     | Technology                                              |
| --------- | ------------------------------------------------------- |
| Framework | ASP.NET Core Blazor Web App, .NET 8, Interactive Server |
| Language  | C# / Razor                                              |
| Styling   | Tailwind CSS v4 (via `@tailwindcss/cli`)                |
| Data      | In-memory mock data served by a singleton service       |

---

## 🗺️ Routes

| Route          | Component             | Description                            |
| -------------- | --------------------- | -------------------------------------- |
| `/`            | `Home.razor`          | Hero, category cards, featured recipes |
| `/our-story`   | `OurStory.razor`      | About the bakery and its values        |
| `/catalog`     | `RecipeCatalog.razor` | Searchable, filterable recipe grid     |
| `/recipe/{id}` | `RecipeDetail.razor`  | Ingredient checklist and baking steps  |

---

## 🏗️ Project Structure

```text
LittleCrumbs/
├── Components/
│   ├── App.razor                 # HTML shell, stylesheet links, blazor.web.js
│   ├── Routes.razor              # Router, default layout
│   ├── Layout/
│   │   └── MainLayout.razor      # Sticky header, body, footer
│   └── Pages/
│       ├── Home.razor
│       ├── OurStory.razor
│       ├── RecipeCatalog.razor
│       └── RecipeDetail.razor
├── Models/
│   └── RecipeModel.cs            # RecipeModel, IngredientItem, BakingStepItem, ReviewItem
├── Services/
│   └── RecipeService.cs          # Mock data, lookup, and title/category filtering
├── Styles/
│   └── app.css                   # Tailwind v4 source (@import "tailwindcss";)
├── wwwroot/
│   ├── css/app.css               # Compiled Tailwind output
│   └── images/                   # Recipe and category photos
├── Program.cs                    # Service registration and middleware
└── package.json                  # Tailwind CLI dev dependencies
```

`RecipeService` is registered as a singleton in `Program.cs` and injected into pages that need recipe data.

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (for the Tailwind CLI)

### Install

```bash
cd LittleCrumbs
dotnet restore
npm install
```

### Build the styles

Tailwind compiles `Styles/app.css` into `wwwroot/css/app.css`. Keep this running in one terminal while you develop:

```bash
npx @tailwindcss/cli -i ./Styles/app.css -o ./wwwroot/css/app.css --watch
```

For a one-off build, drop `--watch` (add `--minify` for production).

### Run the app

In a second terminal:

```bash
dotnet watch run
```

The development profiles listen on:

- `https://localhost:7025`
- `http://localhost:5161`

---

## ⚠️ Known Issues & Next Steps

- **Duplicate recipe data:** `RecipeCatalog.razor` holds its own list of 6 recipes, while `RecipeService` only has 3 (IDs 1-3). Opening recipes 4-6 shows "Recipe not found". Moving all recipes into `RecipeService` and having the catalog use `SearchAndFilter()` would fix this.
- **Croissant image path:** `RecipeService` points to `Flaky Butter Croissants.jpg`, but the file in `wwwroot/images` is `.jpeg`.
- **Serving scaler:** The model stores `Servings`, but the detail page does not yet scale ingredient amounts. `Amount` is currently a plain string, so scaling would need numeric quantities and units.
- **Breadcrumbs:** Recipe pages have a back button but no breadcrumb trail yet.
- **Search placeholder:** The catalog search box mentions descriptions, but filtering matches titles only.
- **Template leftovers:** `Counter.razor`, `Weather.razor`, `NavMenu.razor`, and the Bootstrap files come from the default Blazor template and are not used by the bakery layout.
- **No `npm` scripts:** `package.json` has no build script for Tailwind; use the command above (or add `build:css` / `watch:css` scripts).

---

## 📄 License

No license has been specified for this project yet.
