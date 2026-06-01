# Final project for Nackademin.

This repository is showing the project for my final exam to become a web-developer. I removed the YAML-workflow and the appsettings credentials. 

Below I have used claude.ai turn my projectplan and final report into markdown. 

---

# Projectplan

## Short Project Description

I will build a website for my brother's furniture restoration company.

## Requirements

### Functional Requirements

- The home page should convey the company's message and have a CTA that leads to the contact page.
- The services page should display the various services the company offers to customers.
- The about page should contain an image and text describing the owner of the company.
- The portfolio page should contain images showing both before and after restoration, and link to Instagram.
- The contact page should display a Google map to the company and various ways for the customer to contact the company.
- All pages should have some form of CTA to contact the company.
- Contact information should be present in the footer on all pages.

### Non-Functional Requirements

- The site should use Umbraco CMS so that the owner can easily manage the content.
- It should be possible to log in to the Umbraco back-office with Microsoft Entra Id.
- The website should use HTTPS.
- A sitemap should exist together with a robots.txt.
- URLs should work for Swedish words.
- Lighthouse should show 100 points on SEO.
- Since a large portion of users will be visiting the site on mobile, it should be adapted for mobile.
- The Umbraco back-office and login page should be adapted to the company's graphic profile.

## Timeline

| Week | Tasks |
|------|-------|
| Week 1 | Build a foundation in Umbraco CMS. Basic page structure and HTML. |
| Week 2 | CSS styling of all pages. |
| Week 3 | Testing and finalizing styling. Publishing the site on Azure. |




---





# Final Report:

<div align="center">
  
  # Furniture Restoration
  ### Simon R
  ### Nackademin
  ### CMS24: Examination.
  ### May 22, 2026
  
</div>

---

## Table of Contents

- [Introduction](#introduction)
- [Technologies](#technologies)
  - [Languages & Frameworks](#languages--frameworks)
  - [Umbraco 17 CMS](#umbraco-17-cms)
  - [Microsoft Azure](#microsoft-azure)
  - [Microsoft Entra Id](#microsoft-entra-id)
  - [XUnit](#xunit)
  - [Git/GitHub](#gitgithub)
  - [CI/CD Pipeline](#cicd-pipeline)
- [System](#system)
  - [Pages & Purpose](#pages--purpose)
    - [Home Page](#home-page)
    - [About Page](#about-page)
    - [Service Page](#service-page)
    - [Portfolio Page](#portfolio-page)
    - [Contact Page](#contact-page)
    - [Sitemap](#sitemap)
    - [Page Not Found](#page-not-found)
- [Implementation](#implementation)
  - [Controllers, View-Models and Services](#controllers-view-models-and-services)
  - [Components](#components)
  - [Security](#security)
  - [Accessibility](#accessibility)
  - [Caching](#caching)
  - [Sitemap Service](#sitemap-service)
  - [U-Sync](#u-sync)
  - [Backoffice And Login Customization](#backoffice-and-login-customization)
  - [Design of the Frontend](#design-of-the-frontend)
- [Testing](#testing)
- [Deployment](#deployment)
- [Reflection](#reflection)
  - [Future Improvements](#future-improvements)
  - [Conclusion](#conclusion)

---

## Introduction

My older brother started a furniture restoration company at the end of 2025. He has been using a WordPress blog to advertise the company and it looks very much like an amateur site which doesn't give a good feeling when a user visits it.

He had a text on the site which said that he was having someone make a website for him but no date for when it was supposed to be finished.

I decided to make him a temporary website which, hopefully, looked better and offered a tiny bit more functionality while he waited.

I knew I wanted to use a CMS (Content Management System) to both simplify the creation of the website and to give him an easy way to control the content.

After having looked at possibly creating a Next.js app with Sanity CMS the decision landed instead at Umbraco.

Umbraco offers a nicely designed and intuitive back-office which is easy for anyone to use. And even though I would have learned more from building the site in Sanity, time was also limited.

During development, the company's new website was completed meaning this project became primarily a learning experience and assignment submission.

---

## Technologies

### Languages & Frameworks

**HTML**
HTML (Hypertext Markup Language) is used to structure websites. HTML5 was used for semantic page structure.

**CSS**
CSS (Cascading Style Sheet) was used for styling and responsive layout.

**JavaScript & Lit.js**
JavaScript is the third language of the web. You use it to modify both HTML and CSS in runtime. Lit.js is a library with which you create lightweight web components which is what makes up most of the Umbraco back-office.

When making changes to the Umbraco back-office you utilize a combination of Lit.js and JavaScript. You can also use TypeScript, but it is not needed since Umbraco turns your JavaScript into TypeScript when building the app.

**C#**
C# is a coding language that runs on the .NET framework. It is object oriented and type safe. In this project C# is the primary language for the backend logic, the controllers and services. It was created by Microsoft.

### Umbraco 17 CMS

Umbraco is an open-source content management system (CMS) which gives you an easy to use back-office which you can customize for the final user through the creation of datatypes, document-types, compositions and element types.

Umbraco 17 is the latest LTS-version (Long Term Support) of Umbraco.

### Microsoft Azure

Azure is Microsoft's cloud computing platform. It offers a wide range of solutions for hosting websites, databases and more for both the individual programmer and huge corporations around the world.

### Microsoft Entra Id

Microsoft Entra Id is an identity and access management system which has been added to the project through a community created solution.

It is used to offload the authentication, authorization and user management to the Azure portal. It also makes it so that we can use MFA (Multi-Factor Authentication) for more safety of the CMS content.

### XUnit

XUnit is a free and open-source unit testing tool for C#.

### Git/GitHub

Git is a version control system which is being used to give the security of being able to make changes or mistakes without having to risk starting over from scratch.

Most of the work for this project has been done in separate feature-branches under the dev-branch to then get merged into the developer branch before finally being merged to the main branch from which the website is deployed.

GitHub is the cloud-based hosting site which is used to store the code.

### CI/CD Pipeline

CI/CD (Continuous Integration/Continuous Deployment) pipeline is written in yaml-code. You can add one to your project when deploying it to the web to redeploy the site with the new code you merged into a branch of your choosing. You can also set rules through the pipeline if you for instance only want your deployment to happen if all your tests pass. If you want to do that you add a layer in the pipeline where a virtual machine will build your application and run the tests. If the tests pass it will move to the next step which would be the deployment.

In this project I am only using the pipeline to redeploy the site when merges are made to the main branch.

---

## System

### Pages & Purpose

All pages are using the same header to assist the user in navigating around the website. The links are brought in dynamically from the CMS. The header also contains an icon made with ChatGPT which redirects back to the home page when clicked.

They are also using the same footer which displays the address, opening hours, social media links, an email and phone number through which visitors can contact the company.

Each page can have a CTA (Call to Action) if it is added inside the CMS. It takes the form of a button which has the message on it.

#### Home Page

The home page is a simple landing page which brings the user in and allows the owner to display an image and a message.

#### About Page

The about page allows for a longer introduction of the owner and, in the future, the company employees. It displays an image of the person, which title they have in the company and an introduction text.

#### Service Page

The service page is kept simple with title and text pairs which display which types of restoration services the company offers.

#### Portfolio Page

The portfolio page gives the owner a chance to display the work that has previously been done at the shop through images and text.

If only one image is added the image will be static whereas if more than one image is added the images will cycle with a couple of seconds interval which allows the showing of before and after restoration.

#### Contact Page

The contact page shows a Google map so that the user can easier find their way to the workshop. It also has two extra buttons for the contacting options which are available right now.

A contact form would make a lot of sense here, but for lack of time I skipped it. I would just make a contact form with Umbraco forms and make it so that the user can attach photos of the furniture they want to have fixed, multiple photos at around 5MB per image, and connect it through a mailjet-service which gets fed through a controller to send it on to an email address of the owners choosing.

#### Sitemap

A sitemap has been added through a document type with a template in the CMS, but it gets filled from a sitemap-service which finds the home page at root and its child pages from the CMS before creating the XML (Extensible Markup Language) text which gets displayed on the sitemap page.

#### Page Not Found

A 404 page has been added to handle when people try to navigate to URLs which don't exist. It contains a simple text message and at least one button which redirects the visitor back to the frontpage.

If the owner of the site has added a CTA on the page in the CMS, then there will be an additional button for that CTA.

---

## Implementation

### Controllers, View-Models and Services

When creating websites with Umbraco you can go the route of making a couple of reusable template documents to which you add a single blocklist which the user can populate with element types that you create for them. It is a very good way if you have a big website which will have lots of content and you want to give a lot of freedom to the owner.

Another way, for a smaller website like the one I have made, is making the couple of pages needed and only really giving the specific fields and blocklists which that page needs. The owner can still choose which content to display, but the customization options are limited. The biggest benefit in this is speed.

This approach results in a more MVC-oriented architecture where Umbraco primarily acts as a content repository and administrative interface. It also significantly reduces development time compared to building a fully custom back-office solution. You use controllers to create the view-models, through services, from the content available and display it in the HTML when the user navigates to each page.

The reason for services is to separate concerns, and we make the code more testable. The use of view-models also adds a layer of safety to the data through abstraction. The view doesn't know anything about the data inside the CMS, only the data after we bring it in and maybe make some changes to it. This structure also helps if we were to add default values for the required fields. In that case we could set those values in the services.

### Components

The header, footer and the social-media icons, inside of the footer, are all implemented as view-components. They each have their own service and fetch their data independently from which page the user is on.

The header-service fetches all children of the home page, and includes the page itself, before screening out the pages which we don't want in the navigation menu like the sitemap and page not found.

The footer-service finds the contact page to extract its content from that page so that the owner doesn't have to add the contact information in several places if for instance we did a specific document for the footer itself.

The social-media icons are added on the home page in the CMS and gets fetched in a similar way to the contact information for the footer.

### Security

#### Microsoft Entra Id

Entra Id has been added to the project to make sure that only people that have been added to the Entra Id configuration are able to login. But more importantly, it makes it so that we can utilize MFA (Multi Factor Authentication) from Microsoft which should make us even safer.

In the community solution I used you can utilize the groups in your Entra Id to add the Umbraco user to Umbraco groups in the back-office. You use the group id guid from the Entra Id and tie it to the group alias from Umbraco in your appsettings file. You can also set a default group that all Umbraco users should be added to. These connections are set on each login.

#### Content Security Policy

A content security policy was added in the program file. It is a security header which tells the browser which sources it is allowed to load resources from. It is the primary defence against attacks like cross site scripting.

When first adding it, the Google map on the contact page stopped working and there was an issue with browser link, but with some help from Claude AI, I got it working again. We expanded the whitelist to the Google domain for maps and the localhost connections for browser link.

#### Environment-specific Configuration

Browser link is a Visual Studio development tool which requires WebSocket connections for localhost. They are included in the `connect-src` but only really needed during development since browser link doesn't run in production.

#### Security Headers

Two more security headers were added along the CSP.

- **X-Frame-Options** is set to `sameorigin` to prevent the site being embedded in an iframe on another domain.
- **X-Content-Type-Options** is set to `nosniff` which tells the browser to trust the content-type header and not try to guess what a file is. Without it a browser might interpret an uploaded text file as JS and execute it.

#### Robots.txt

A `robots.txt` file was added to the project to set rules for web crawlers, like Google, on what they are allowed to index for their search engines and which endpoints they should not touch.

Since my project was not going to be used, I disallowed the entire website but in the image I also display how I would have had it if we were going to use it.

### Accessibility

#### Semantic HTML

Semantic HTML is when we go away from using the markup only for structuring things but use it to give meaning to the content as well. In the project I have been using markup like `footer`, `header`, `main`, `section` and `nav` instead of just the simple `div`.

This gives the screen-readers that people use more of an indication of where to look for specific things.

Each page is also following a semantic rule to only have a single `h1` and that headings are in ascending order as you descend the page.

#### Aria-Labels

Aria-labels are added to aid screen-readers with mostly things like buttons, links and icons. If using an icon as a button, then an aria-label should be added to describe to the user what the button does.

An example of where it has been added is inside the header where the icon is inside an HTML anchor. The label has been added so that a blind person gets notified that clicking the icon will redirect them to the home page.

If a button has a good enough description in the text of the button, then the label has been skipped.

#### Media

The frontend was also designed to remain usable across different screen sizes.

### Caching

Caching has been added in the program file to make sure that images, CSS and JS files are being cached.

Caching is done to make the website load faster when returning to the site and when navigating around on the site.

The images are saved for a shorter time of a week to start while the CSS and JS files are cached for a year. Might be unnecessary but the thinking was that he might want to change the portfolio content more often than the rest of the content on the site.

### Sitemap Service

The sitemap gets its content from a sitemap-service. The service grabs the home page, all its child-pages which have a meta-description on it and are not of the type `pageNotFound`. It also makes sure the pages are in a published state.

The service then creates the XML sitemap string using a `StringBuilder` and following the sitemap schema with each entry containing a `<loc>` (URL) and `<lastmod>` (last modified date), which is the last time you pressed publish on the page inside the content section of the CMS.

### U-Sync

U-Sync is a free and open-source package for Umbraco. It lets you transfer content which you have created inside of the CMS from one database to another by exporting it into your codebase which gets added to source-control.

During development of the website, I have been using a local database and right before deploying I switched it over to a SQL-database hosted on Azure.

### Backoffice And Login Customization

Customizing the back-office requires the use of Umbraco packages in which you write JSON to specify at which point your code, written using Lit.js in either JS or TS, should run.

The options I use in the project is to either run the code on `backofficeEntryPoint` or `appEntryPoint`. App entry refers to when you navigate to the `/umbraco` endpoint. And back-office entry is when you login.

The changes I have done is mostly just to the colour schemes, title, icon and login page. I use the Umbraco extension registry to remove the default Umbraco themes which you can switch between inside of the CMS and add my own in the theme dropdown to prevent the use of the Umbraco themes.

I managed to find the CSS file of the Umbraco dark theme, in their repository, a while back which contained the CSS variables that Umbraco uses. And using that, together with a couple more variables which I had to find using the inspect tool, I have changed the colours of the back-office. This is done simply by using JS to append the stylesheet link of my CSS file into the head of the back-office.

The login page was easier as there is a full guide in the Umbraco documentation on how to do it and which code is needed.

#### Issues

One of the major issues when trying to customize your back-office is that Umbraco makes updates constantly which makes changes to the way they handle the colours of the back-office.

Sometimes they seem to go away from using the CSS file and its variables, and just do the styling inside of the web-component they updated. This makes that part of the site run after the CSS file, which I made, gets added which then makes their styling overwrite mine.

I have tried different things like trying to use JS or TS to remove components or to add my styling directly into the HTML elements to no avail. I have also tried to add a delay to my own styling getting added but that didn't work either.

### Design of the Frontend

#### The Old Website and Finding Inspiration

The old website was composed of a simple WordPress, single page, blog that had minimal styling and functionality.

Because of that, I began by looking at other websites. One feeling I got while looking at competitors websites is that budget limitations is probably limited within the industry.

I did however find the page for Spagan which I really liked the design of. I didn't need all the different things that they had. They for instance have some sort of web-shop and they can share their school projects, on their about page, which they wrote for their final exams. Since I was making this as a surprise for my brother I couldn't just go and ask him for his.

My first draft was pulling colours from both the WordPress blog and Spagan while most of the structure was heavily inspired by Spagan. The general layout. The idea for the black and white map.

I then looked at things like which type of information is needed for a website like this. The owner should be able to convey information which makes the user want to contact them and the site needs ways to contact the company. I broke that down to different pages and looked for what would be the least number of things you would need on each page for them to serve their purpose, while taking things like cost and the surprise part into account.

For example, I could go with an Instagram API feed on the portfolio page but then we come back to the problem of not being able to ask him for it. So instead, I went the route of creating a card with which he could show the restoration process for now and you could realistically just attach an Instagram post to that same card in the future if needed.

Another thing I did was just use a simple `<iframe>` for the Google map. Spagan clearly use an API for theirs since they have customized theirs more than just make it black and white. My considerations for money and safety came into play here mostly. If I don't manage to secure the website well enough people can get hold of API keys and abuse those which could end up costing more money than you would ever want.

#### Colour Scheme

First, like I wrote above, I went with a beige and orange theme. But later, I wanted to differentiate my site from the others a lot more. I found some pages from which I could look around and take inspiration for the colour combinations and landed on the more forestry green instead of the bright orange.

#### Logo

I decided to let ChatGPT create a new logo for the site as well just giving it a couple of parameters like the company name, what the company does and the colours the site uses.

---

## Testing

Due to the timeframe of the project, testing was focused on the easy business logic which could be done independently from the Umbraco CMS dependencies. The project currently contains just a couple of unit-tests done using XUnit.

The tests target the phone number service as it contains pure validation logic without dependencies from the CMS, database or external services. The tests cover valid, null and invalid inputs to ensure the service outputs a correct string which can be used as a `href` for the phone number.

More complex services were not tested at this time because of their deeper dependencies on Umbraco content structure and runtime context. They would require additional setup and mocking.

No integration or end to end tests were implemented in the current version of the project. If the project were to continue those would have to be made as they would probably provide more value than a simple unit-test. Tools such as Playwright could be used to automate frontend and user-flow testing including navigation and content rendering.

---

## Deployment

I decided to use Microsoft Azure for both the hosting of the website and for the database for production. The database is a simple SQL-Database, and I am using a web app for the site itself.

I didn't bother to add logging or anything at this point. It might be something that would be interesting in the future, if this project was going to be used by my brother, to be able to see and easier block malicious requests.

### Issues

Issues experienced while deploying were mostly happening because I was following a guide where the person was using Umbraco 16, while my version is 17, which led me to have issues which they weren't having. Also, I had added things to the solution which they didn't have and that I had never had before in any project I had published.

#### Issue One – CI/CD Pipeline

When deploying an app, you can choose to let Azure create a CI/CD pipeline for you.

In my solution I had added a second project with the unit-tests in my solution, which the person in the video didn't have.

The tests became an issue since the pipeline which gets created tried to deploy the entire solution, including the testing project.

The issue was identified by adding `ASPNETCORE_ENVIRONMENT` with the value `Development` into the app settings on Azure to get a hold of better error logs when attempting to navigate to the websites URL.

I then used Claude AI to better understand the error code and to make the changes needed to the yaml-code to only deploy the actual presentation project.

#### Issue Two – Microsoft Entra Id

The Entra Id had two issues.

The first was that, in the video, the person was adding app settings with variable names like `umbraco:cms:entra` to reach the correct depth in the appsettings file. But the correct way of writing it is `umbraco__cms__entra` with the double underscore.

The second was that the Entra Id login button was not showing up at all. It was only once I changed `DenyLocalLogin` to `true` in my appsettings file that I received the error message showing that I had forgotten to add the new URI to my Entra Id configuration. It was only after that change that the app tried to redirect me to the Microsoft login screen for the Entra Id.

---

## Reflection

It was hard to come up with something I wanted to build.

Several other project ideas were considered but were ultimately deemed too complex for the timeframe. One was a dessert recipe platform for the restaurant industry but the SQL-schema would be too complex.

Even though it most probably won't ever be used, I still feel glad about what I managed to create, I have done market research by looking at what others have and created something which would be a decent first draft of a website for a small business like my brothers.

### Future Improvements

There are things that I wished I had enough time and experience to add.

- **Newsletter feature** — signing people up on the website and then creating a section inside of the back-office where my brother could create a visually appealing email with both text and images and then to be able to send it out to all the people on the newsletter list. Taking in and storing of the emails in a safe manner would not be a problem. The challenge would be building the section with the interface where he can create and see the email that he is building in real time before sending it on.
- **Scroll animations** — animations on the elements to slowly bring them in as you scroll and navigate around on the site.
- **Umbraco contact form** — They require additional styling customization compared to standard frontend components. I already have the code for a mailjet-service, I would just need to figure out how to send attachments with the emails.

### Conclusion

I set out to create a website for a furniture restoration company using Umbraco 17 and I managed to deliver that. I had never put an Umbraco project live before. The accessibility score I managed to get in Lighthouse was nice to see. During my time in the restaurant industry I always made sure to take the extra time to make food for the allergic or intolerant people so it feels good building something that a person with disability might be able to use.

The biggest thing I learned from all this is probably just the setting an Umbraco site live. It is always a challenge doing that as Microsoft's site is not the easiest to understand.

Even though it will not be used in production, the project has gone through a complete development workflow. If I could change anything I probably would have started sooner on the project to be able to add more things and probably try to finish the documentation earlier that 27 minutes before the assignment ends.
