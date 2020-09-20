using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ISOCertificate.DAL;
using ISOCertificate.Email;
using ISOCertificate.Extensions;
using ISOCertificate.Models;
using ISOCertificate.ViewModels.RequestInputModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ISOCertificate.Controllers
{
    public class InvestigateController : Controller
    {
        private readonly CertificateDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly EmailConfiguration _emailConfig;

        public InvestigateController(CertificateDbContext context, IMapper mapper, IWebHostEnvironment env, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleMgr, IOptions<EmailConfiguration> emailConfig)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
            _roleManager = roleMgr;
            _userManager = userManager;
            _emailConfig = emailConfig.Value;

        }

        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.Name).Value;

            var user = await _userManager.FindByNameAsync(currentUserName);
            var roles = await _userManager.GetRolesAsync(user);


            try
            {
                ViewBag.OccurenceReason = await _context.OccurenceReason.ToListAsync();
                ViewBag.OccurenceType = await _context.OccurenceType.ToListAsync();
                ViewBag.WheatherType = await _context.WheatherType.ToListAsync();
                ViewBag.GroundType = await _context.GroundType.ToListAsync();
                ViewBag.GroundConditionType = await _context.GroundConditionType.ToListAsync();
                ViewBag.IlluminationType = await _context.IlluminationType.ToListAsync();
                ViewBag.ContactType = await _context.ContactType.ToListAsync();
                ViewBag.InjuryType = await _context.InjuryType.ToListAsync();
                ViewBag.IlnessType = await _context.IlnessTypes.ToListAsync();
                ViewBag.BodilyLocationType = await _context.BodilyLocationType.ToListAsync();
                ViewBag.InjuredActionType = await _context.InjuredActionType.ToListAsync();
                ViewBag.ReleaseType = await _context.ReleaseType.ToListAsync();
                ViewBag.ReleasedToType = await _context.ReleasedToType.ToListAsync();
                ViewBag.UnSafeFactType = await _context.UnSafeFactType.ToListAsync();
                ViewBag.UnSafeConditionType = await _context.UnSafeConditionType.ToListAsync();
                ViewBag.MaterialRelease = await _context.MaterialReleasedie.ToListAsync();
                ViewBag.MaterialCategory = await _context.MaterialCategorie.ToListAsync();
                ViewBag.LineTypeCategory = await _context.LineType.ToListAsync();
                ViewBag.Investigate = await _context.Investigate.ToListAsync();
                ViewBag.DocumentType = await _context.DocumentType.ToListAsync();


                //2nd User

                ViewBag.OccurenceCause = await _context.OccurenceCause.ToListAsync();
                ViewBag.OutcomePeople = await _context.OutcomePeople.ToListAsync();
                ViewBag.OutcomeProperty = await _context.OutcomeProperty.ToListAsync();
                ViewBag.OutcomeEnviroment = await _context.OutcomeEnviroment.ToListAsync();
                ViewBag.OutcomeBuisness = await _context.OutcomeBuisness.ToListAsync();
                ViewBag.PossiblePeople = await _context.PossiblePeople.ToListAsync();
                ViewBag.PossibleProperty = await _context.PossibleProperty.ToListAsync();
                ViewBag.PossibleEnviroment = await _context.PossibleEnviroment.ToListAsync();
                ViewBag.PossibleBuisness = await _context.PossibleBuisness.ToListAsync();
                ViewBag.LessonLearned = await _context.LessonLearned.ToListAsync();
                ViewBag.NominateLineTypeCategory = await _context.NominateLineType.ToListAsync();


                //Showtable
                ViewBag.InvestList = await _context.Investigate
                                       .Include(p => p.OccurenceReason).Include(p => p.OccurenceType).Include(p => p.WheatherType)
                                       .Include(p => p.GroundType).Include(p => p.GroundConditionType).Include(p => p.IlluminationType)
                                       .Include(p => p.ContactType).Include(p => p.InjuryType).Include(p => p.IlnessType)
                                       .Include(p => p.BodilyLocationType).Include(p => p.InjuredActionType).Include(p => p.ReleaseType)
                                       .Include(p => p.ReleasedToType)
                                        .Where(p => p.Status == 1 && p.SType == 1)
                                       .ToListAsync();


                ViewBag.IncidentList = await _context.Investigate
                                      .Include(p => p.OccurenceCause).Include(p => p.OutcomePeople).Include(p => p.OutcomeProperty)
                                      .Include(p => p.OutcomeEnviroment).Include(p => p.OutcomeBuisness).Include(p => p.PossibleBuisness)
                                      .Include(p => p.PossibleProperty).Include(p => p.PossibleEnviroment).Include(p => p.PossiblePeople)
                                      .Include(p => p.LessonLearned)
                                       .Where(p => p.Status == 1 && p.SType == 2)
                                      .ToListAsync();



            }
            catch (Exception e)
            {
                e.InnerException.Message.ToString();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvestigate(InvestigateCreateViewModel model)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = await _userManager.FindByNameAsync(currentUserName);

            int Id = model.Id;

            try
            {
                if (Id == 0)
                {
                    var entity = _mapper.Map<Investigate>(model);

                    await _context.Investigate.AddAsync(entity);
                    await _context.SaveChangesAsync();

                    foreach (var m in model.Materials)
                    {
                        var material = _mapper.Map<Material>(m);
                        material.InvestigateId = entity.Id;
                        await _context.Material.AddAsync(material);
                    }
                    foreach (var l in model.InvestigateLines)
                    {
                        var lines = _mapper.Map<InvestigateLine>(l);
                        lines.InvestigateId = entity.Id;
                        await _context.InvestigateLine.AddAsync(lines);
                    }
                    foreach (var image in model.Images)
                    {
                        var fileName = await image.Photo.SaveAsync(_env.WebRootPath, "investigate/");
                        var file = new Image

                        {
                            DocumentTypeId = image.DocumentTypeId,
                            DocumentName = image.DocumentName,
                            Attachment = fileName
                        };

                        file.InvestigateId = entity.Id;
                        await _context.Image.AddAsync(file);
                    }

                    foreach (var u in model.UnSafeFactTypeId)
                    {
                        InvestigateUnsafeFact unFact = new InvestigateUnsafeFact()
                        {
                            InvestigateId = entity.Id,
                            UnSafeFactTypeId = u
                        };
                        await _context.InvestigateUnsafeFact.AddAsync(unFact);
                    }


                    foreach (var c in model.UnSafeConditionTypeId)
                    {
                        InvestigateUnsafe unsafes = new InvestigateUnsafe()
                        {
                            InvestigateId = entity.Id,
                            UnSafeConditionTypeId = c
                        };
                        await _context.InvestigateUnsafe.AddAsync(unsafes);
                    }

                    await _context.SaveChangesAsync();

                    entity.Status = 1; // 1 olanlar aktiv, 0-olanlar passivdi DELETE de isdf oluncaq
                    entity.SType = 1; //1  Investigate Module nun tipidi.
                    entity.UserId = currentUserName;
                    entity.ConfirmStatus = 0;
                    await _context.SaveChangesAsync();

                    //Send notfication to MAIL

                    SmtpClient client = new SmtpClient(_emailConfig.SmtpServer, _emailConfig.Port);
                    client.UseDefaultCredentials = false;
                    client.TargetName = "ISOCertificate";
                    client.Credentials = new NetworkCredential(_emailConfig.From, _emailConfig.Password);
                    MailMessage message = new MailMessage(new MailAddress(_emailConfig.From, "ISO Certificate"), new MailAddress(_emailConfig.From));
                    client.EnableSsl = true;
                    message.IsBodyHtml = true;
                    message.Subject = "ISO report confirm";
                    message.Body = @"<html>
                        <body>
                        <p><strong> Dear Customer,</ strong ></p >
                             <p>Please login to your account to view new reports:</p>" + " " + "https://localhost:44348/Account/LogIn" + "<br>" + "<p>If you have any problem you can contact with your administrator .</p><br><br><p> Kind Regards,</p>" + "<p> ISO Certificate </p>" +
                        "</body> " +
                        "</html>";
                    message.IsBodyHtml = true;

                    await client.SendMailAsync(message);

                    //Send notfication to MAIL
                }
                else
                {
                    var entity = await _context.Investigate
                        .Include(p => p.InvestigateLines)
                        .Include(p => p.Materials)
                        .Include(p => p.Images)
                        .SingleOrDefaultAsync(p => p.Id == model.Id);

                    entity = _mapper.Map(model, entity);

                    _context.Investigate.Update(entity);
                    await _context.SaveChangesAsync();

                    foreach (var lineId in model.InvestigateLines)
                    {
                        IEnumerable<InvestigateLine> oldLine = _context.InvestigateLine.Where(p => p.InvestigateId == entity.Id);

                        if (lineId != null)
                        {
                            _context.InvestigateLine.RemoveRange(oldLine);

                            var lines = _mapper.Map<InvestigateLine>(lineId);
                            lines.InvestigateId = entity.Id;
                            entity.InvestigateLines.Add(lines);
                        }
                    }

                    foreach (var matId in model.Materials)
                    {
                        IEnumerable<Material> oldMat = _context.Material.Where(p => p.InvestigateId == entity.Id);

                        if (matId != null)
                        {
                            _context.Material.RemoveRange(oldMat);

                            var material = _mapper.Map<Material>(matId);
                            material.InvestigateId = entity.Id;
                            entity.Materials.Add(material);
                        }


                        IEnumerable<InvestigateUnsafeFact> oldTags = _context.InvestigateUnsafeFact.Where(p => p.InvestigateId == entity.Id);

                        if (model.UnSafeFactTypeId != null)
                        {
                            _context.InvestigateUnsafeFact.RemoveRange(oldTags);

                            foreach (var u in model.UnSafeFactTypeId)
                            {
                                InvestigateUnsafeFact unFact = new InvestigateUnsafeFact()
                                {
                                    InvestigateId = entity.Id,
                                    UnSafeFactTypeId = u
                                };
                                await _context.InvestigateUnsafeFact.AddAsync(unFact);

                            }
                        }

                        IEnumerable<InvestigateUnsafe> oldSafe = _context.InvestigateUnsafe.Where(p => p.InvestigateId == entity.Id);

                        if (model.UnSafeConditionTypeId != null)
                        {
                            _context.InvestigateUnsafe.RemoveRange(oldSafe);

                            foreach (var c in model.UnSafeConditionTypeId)
                            {
                                InvestigateUnsafe unsafes = new InvestigateUnsafe()
                                {
                                    InvestigateId = entity.Id,
                                    UnSafeConditionTypeId = c
                                };
                                await _context.InvestigateUnsafe.AddAsync(unsafes);

                            }
                        }
                        string fileName = "";
                        var currentPhoto = "";
                        var path = "";

                        if (model.Images != null)
                        {
                            IEnumerable<Image> oldImg = _context.Image.Where(p => p.InvestigateId == entity.Id);

                            foreach (var photo in oldImg)
                            {
                                string computerPhoto = Path.Combine(_env.WebRootPath, "images/", photo.Attachment);
                                currentPhoto = Path.Combine("../images/", photo.Attachment);
                                path = photo.Attachment;

                                //if (System.IO.File.Exists(computerPhoto))
                                //{
                                //    System.IO.File.Delete(computerPhoto);
                                //}

                                _context.RemoveRange(oldImg);
                            }


                            foreach (var p in model.Images)
                            {
                                if (p != null)
                                {
                                    fileName = string.Empty;
                                    if (p.Photo.FileName.Length > 0 && p.Photo.FileName == currentPhoto)
                                    {
                                        fileName = path;
                                    }
                                    else
                                    {
                                        fileName = await p.Photo.SaveAsync(_env.WebRootPath, "investigate/");
                                    }
                                    Image file = new Image
                                    {
                                        InvestigateId = entity.Id,
                                        Attachment = fileName,
                                        DocumentTypeId = p.DocumentTypeId,
                                        DocumentName = p.DocumentName
                                    };

                                    entity.Images.Add(file);
                                }
                            }

                        }
                        entity.Status = 1; // 1 olanlar aktiv, 0-olanlar passivdi DELETE de isdf oluncaq
                        entity.SType = 1;
                        entity.UserId = currentUserName;
                        await _context.SaveChangesAsync();

                    }
                }
            }
            catch (Exception e)
            {
                e.InnerException.Message.ToString();
            }

            return RedirectToAction("Index", "Investigate");


        }

        [HttpPost]
        public async Task<JsonResult> Edit(int id)
        {

            var query = await _context.Investigate
                                   .Include(p => p.OccurenceReason).Include(p => p.OccurenceType).Include(p => p.WheatherType)
                                   .Include(p => p.GroundType).Include(p => p.GroundConditionType).Include(p => p.IlluminationType)
                                   .Include(p => p.ContactType).Include(p => p.InjuryType).Include(p => p.IlnessType)
                                   .Include(p => p.BodilyLocationType).Include(p => p.InjuredActionType).Include(p => p.ReleaseType)
                                   .Include(p => p.ReleasedToType).Include(p => p.UnSafeConditionType).Include(p => p.UnSafeFactType)
                                   .Where(p => p.Id == id)
                                   .ToListAsync();

            string value = string.Empty;

            value = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }

        [HttpPost]
        public async Task<JsonResult> DeliverLineFill_edit(int id)
        {

            var query = await _context.InvestigateLine.Include(p => p.LineType)
                                   .Where(p => p.InvestigateId == id)
                                   .ToListAsync();

            string value = string.Empty;

            value = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }

        [HttpPost]
        public async Task<JsonResult> DeliverMaterialLineFill_edit(int id)
        {

            var query = await _context.Material.Include(p => p.MaterialCategory).Include(p => p.MaterialReleased)
                                   .Where(p => p.InvestigateId == id)
                                   .ToListAsync();

            string value = string.Empty;

            value = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }

        [HttpPost]
        public async Task<JsonResult> FilesFill_edit(int id)
        {

            var query = await _context.Image.Include(p => p.DocumentType)
                                   .Where(p => p.InvestigateId == id)
                                   .ToListAsync();

            string value = string.Empty;

            value = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }

        [HttpGet]
        public async Task<JsonResult> Delete(int id)    //datalarin status 0-a beraber edirik, data silinmemelidi.
        {

            Investigate query = await _context.Investigate.FindAsync(id);

            query.Status = 0;

            await _context.SaveChangesAsync();

            string value = string.Empty;

            value = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(value);
        }

        [HttpPost]
        public JsonResult GetAutoNoIncrement()
        {
            string nyNumber = "";

            var entity = _context.Investigate.Where(p => p.SType == 1).Max(p => p.No);
            var IR = "IR";

            var v_pref = IR + DateTime.Parse(DateTime.Now.Date.ToString()).Year.ToString().Substring(2, 2) + "" + DateTime.Parse(DateTime.Now.Date.ToString()).Month.ToString("00") + "-";

            if (entity == null)
            {
                nyNumber = v_pref + "1";
            }
            else if (entity != "")
            {
                string input = entity;
                int lastIndex = input.LastIndexOf('-'); //7
                string lastNumber = input.Substring(lastIndex + 1);  //1
                string increment = (int.Parse(lastNumber) + 1).ToString();
                nyNumber = string.Concat(input.Substring(0, lastIndex + 1), increment);
            }
            else
            {
                nyNumber = v_pref + "0001";
            }
            return Json(nyNumber);
        }

        //*********************************************************FOR 2nd user

        [HttpPost]
        public async Task<IActionResult> CreateIncident(InvestigateCreateIncidentViewModel model)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = await _userManager.FindByNameAsync(currentUserName);

            int Id = model.Id;

            try
            {
                if (Id == 0)
                {
                    var entity = _mapper.Map<Investigate>(model);

                    await _context.Investigate.AddAsync(entity);
                    await _context.SaveChangesAsync();

                    foreach (var m in model.EventLines)
                    {
                        var eventline = _mapper.Map<EventLine>(m);
                        eventline.InvestigateId = entity.Id;
                        await _context.EventLine.AddAsync(eventline);
                    }
                    foreach (var m in model.PreventLines)
                    {
                        var preventline = _mapper.Map<PreventLine>(m);
                        preventline.InvestigateId = entity.Id;
                        await _context.PreventLine.AddAsync(preventline);
                    }
                    foreach (var m in model.EvaluationLines)
                    {
                        var evalution = _mapper.Map<EvaluationLine>(m);
                        evalution.InvestigateId = entity.Id;
                        await _context.EvaluationLine.AddAsync(evalution);
                    }
                    foreach (var l in model.NominateLines)
                    {
                        var lines = _mapper.Map<NominateLine>(l);
                        lines.InvestigateId = entity.Id;
                        await _context.NominateLine.AddAsync(lines);
                    }
                    foreach (var image in model.Images)
                    {
                        var fileName = await image.Photo.SaveAsync(_env.WebRootPath, "incident/");
                        var file = new Image

                        {
                            DocumentTypeId = image.DocumentTypeId,
                            DocumentName = image.DocumentName,
                            Attachment = fileName
                        };

                        file.InvestigateId = entity.Id;
                        await _context.Image.AddAsync(file);
                    }
                    entity.Status = 1; // 1 olanlar aktiv, 0-olanlar passivdi DELETE de isdf oluncaq
                    entity.SType = 2; //1  Investigate Module nun tipidi.
                    entity.ConfirmStatus = 0; //2ci user deyisene qeder 0 qalir
                    entity.UserId = currentUserName;
                    await _context.SaveChangesAsync();

                    //Send notfication to MAIL

                    SmtpClient client = new SmtpClient(_emailConfig.SmtpServer, _emailConfig.Port);
                    client.UseDefaultCredentials = false;
                    client.TargetName = "ISOCertificate";
                    client.Credentials = new NetworkCredential(_emailConfig.From, _emailConfig.Password);
                    MailMessage message = new MailMessage(new MailAddress(_emailConfig.From, "ISO Certificate"), new MailAddress(_emailConfig.From));
                    client.EnableSsl = true;
                    message.IsBodyHtml = true;
                    message.Subject = "ISO report confirm";
                    message.Body = @"<html>
<body>
<p><strong> Dear Customer,</ strong ></p >
     <p>Please login to your account to view new reports:</p><br> " + "https://localhost:44348/Account/LogIn" + "<br>" + "<p>If you have any problem you can contact with your administrator .</p><br><br><p> Kind Regards,</p>" + "<p> ISO Certificate </p>" +
"</body> " +
"</html>";
                    message.IsBodyHtml = true;

                    await client.SendMailAsync(message);

                    //Send notfication to MAIL
                }
                else
                {
                    var entity = await _context.Investigate
                        .Include(p => p.InvestigateLines)
                        .Include(p => p.Materials)
                        .Include(p => p.Images)
                        .SingleOrDefaultAsync(p => p.Id == model.Id);

                    entity = _mapper.Map(model, entity);

                    _context.Investigate.Update(entity);
                    await _context.SaveChangesAsync();

                    foreach (var lineId in model.NominateLines)
                    {
                        IEnumerable<NominateLine> oldLine = _context.NominateLine.Where(p => p.InvestigateId == entity.Id);

                        if (lineId != null)
                        {
                            _context.NominateLine.RemoveRange(oldLine);

                            var lines = _mapper.Map<NominateLine>(lineId);
                            lines.InvestigateId = entity.Id;
                            entity.NominateLine.Add(lines);
                        }
                    }

                    foreach (var matId in model.EventLines)
                    {
                        IEnumerable<EventLine> oldMat = _context.EventLine.Where(p => p.InvestigateId == entity.Id);

                        if (matId != null)
                        {
                            _context.EventLine.RemoveRange(oldMat);

                            var eventLine = _mapper.Map<EventLine>(matId);
                            eventLine.InvestigateId = entity.Id;
                            entity.EventLines.Add(eventLine);
                        }
                    }

                    foreach (var matId in model.EvaluationLines)
                    {
                        IEnumerable<EvaluationLine> oldMat = _context.EvaluationLine.Where(p => p.InvestigateId == entity.Id);

                        if (matId != null)
                        {
                            _context.EvaluationLine.RemoveRange(oldMat);

                            var evaluationLine = _mapper.Map<EvaluationLine>(matId);
                            evaluationLine.InvestigateId = entity.Id;
                            entity.EvaluationLines.Add(evaluationLine);
                        }
                    }

                    foreach (var matId in model.PreventLines)
                    {
                        IEnumerable<PreventLine> oldMat = _context.PreventLine.Where(p => p.InvestigateId == entity.Id);

                        if (matId != null)
                        {
                            _context.PreventLine.RemoveRange(oldMat);

                            var preventLine = _mapper.Map<PreventLine>(matId);
                            preventLine.InvestigateId = entity.Id;
                            entity.PreventLines.Add(preventLine);
                        }
                    }


                    string fileName = "";
                    var currentPhoto = "";
                    var path = "";

                    if (model.Images != null)
                    {
                        IEnumerable<Image> oldImg = _context.Image.Where(p => p.InvestigateId == entity.Id);

                        foreach (var photo in oldImg)
                        {
                            string computerPhoto = Path.Combine(_env.WebRootPath, "images/", photo.Attachment);
                            currentPhoto = Path.Combine("../images/", photo.Attachment);
                            path = photo.Attachment;

                            //if (System.IO.File.Exists(computerPhoto))
                            //{
                            //    System.IO.File.Delete(computerPhoto);
                            //}

                            _context.RemoveRange(oldImg);
                        }

                        foreach (var p in model.Images)
                        {
                            if (p != null)
                            {
                                fileName = string.Empty;
                                if (p.Photo.FileName.Length > 0 && p.Photo.FileName == currentPhoto)
                                {
                                    fileName = path;
                                }
                                else
                                {
                                    fileName = await p.Photo.SaveAsync(_env.WebRootPath, "investigate/");
                                }
                                Image file = new Image
                                {
                                    InvestigateId = entity.Id,
                                    Attachment = fileName,
                                    DocumentTypeId = p.DocumentTypeId,
                                    DocumentName = p.DocumentName
                                };

                                entity.Images.Add(file);
                            }
                        }

                    }
                    entity.Status = 1; // 1 olanlar aktiv, 0-olanlar passivdi DELETE de isdf oluncaq
                    entity.SType = 2;
                    entity.ConfirmStatus = 0;
                    entity.UserId = currentUserName;
                    await _context.SaveChangesAsync();

                }
            }
            catch (Exception e)
            {
                e.InnerException.Message.ToString();
            }

            return RedirectToAction("Index", "Investigate");
        }

        [HttpPost]
        public JsonResult GetAutoNomIncrement()
        {
            string nyNumber = "";

            var entity = _context.Investigate.Where(p => p.SType == 2).Max(p => p.No);
            var IR = "IR";

            var v_pref = IR + DateTime.Parse(DateTime.Now.Date.ToString()).Year.ToString().Substring(2, 2) + "" + DateTime.Parse(DateTime.Now.Date.ToString()).Month.ToString("00") + "-";

            if (entity == null)
            {
                nyNumber = v_pref + "1";
            }
            else if (entity != "")
            {
                string input = entity;
                int lastIndex = input.LastIndexOf('-'); //7
                string lastNumber = input.Substring(lastIndex + 1);  //1
                string increment = (int.Parse(lastNumber) + 1).ToString();
                nyNumber = string.Concat(input.Substring(0, lastIndex + 1), increment);
            }
            else
            {
                nyNumber = v_pref + "0001";
            }
            return Json(nyNumber);
        }

        [HttpPost]
        public async Task<JsonResult> EditIncident(int id)
        {

            var query = await _context.Investigate
                                      .Include(p => p.OccurenceCause).Include(p => p.OutcomePeople).Include(p => p.OutcomeProperty)
                                      .Include(p => p.OutcomeEnviroment).Include(p => p.OutcomeBuisness).Include(p => p.PossibleBuisness)
                                      .Include(p => p.PossibleProperty).Include(p => p.PossibleEnviroment).Include(p => p.PossiblePeople)
                                      .Include(p => p.LessonLearned)
                                       .Where(p => p.Status == 1 && p.SType == 2)
                                      .ToListAsync();

            string value = string.Empty;

            value = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }

        [HttpPost]
        public async Task<JsonResult> DeliverNominatedLineFill_edit(int id)
        {

            var query = await _context.NominateLine.Include(p => p.TeamType)
                                   .Where(p => p.InvestigateId == id)
                                   .ToListAsync();

            string value = string.Empty;

            value = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }

        [HttpPost]
        public async Task<JsonResult> DeliverEventLineFill_edit(int id)
        {

            var query = await _context.EventLine
                                   .Where(p => p.InvestigateId == id)
                                   .ToListAsync();

            string value = string.Empty;

            value = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }

        [HttpPost]
        public async Task<JsonResult> DeliverPreventLineFill_edit(int id)
        {

            var query = await _context.PreventLine
                                   .Where(p => p.InvestigateId == id)
                                   .ToListAsync();

            string value = string.Empty;

            value = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }

        [HttpPost]
        public async Task<JsonResult> DeliverEvalutionFill_edit(int id)
        {

            var query = await _context.EvaluationLine
                                   .Where(p => p.InvestigateId == id)
                                   .ToListAsync();

            string value = string.Empty;

            value = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value);
        }

        [HttpGet]
        public async Task<JsonResult> CompleteIncident(int id)
        {

            Investigate query = await _context.Investigate.FindAsync(id);

            query.ConfirmStatus = 1;

            await _context.SaveChangesAsync();

            string value = string.Empty;

            value = JsonConvert.SerializeObject(query, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(value);
        }

        //Print
        public async Task<IActionResult> Print(int id)
        {
            var model = await _context.Investigate
                .Include(p => p.LessonLearned)
                .Include(p => p.OccurenceCause)
                .Include(p => p.OutcomeBuisness)
                .Include(p => p.OutcomeEnviroment)
                .Include(p => p.OutcomePeople)
                .Include(p => p.OutcomeProperty)
                .Include(p => p.PossibleBuisness)
                .Include(p => p.PossibleEnviroment)
                .Include(p => p.PossiblePeople)
                .Include(p => p.PossibleProperty)
                .Include(p => p.NominateLine).Include(p => p.EventLines)
                 .Include(p => p.PreventLines).Include(p => p.EvaluationLines).Include(p => p.Images).Where(p => p.Id == id).ToListAsync();

            ViewBag.BRheader = model;
            return View();
        }


    }
}