using Forms.DataAccess.Repository.IRepository;
using Forms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FormsWeb.Controllers
{
    public class FormsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FormsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            ////var frm = new FrmForms()
            ////{
            ////    TitleAr = "test",
            ////    TitleEn = "test",
            ////    FrmQuestions = new List<FrmQuestions>() { new FrmQuestions() { Question = "test qs" } }
            ////};
            ////_unitOfWork.Form.Add(frm);
            ////_unitOfWork.Save();
            return View();
        }
        //GET-Questions
        public IActionResult FormQuestions(FrmForms obj)
        {
            var form = _unitOfWork.Form.GetFirstOrDefault(x => x.Id == obj.Id);
            var Lst1 = _unitOfWork.Controltype.GetAll().ToList();
            var ControlTypeList = Lst1.Select(
                   u => new SelectListItem
                   {
                       Text = u.Type,
                       Value = u.Id.ToString()
                   });
            ViewBag.ControlTypeList = ControlTypeList;

            var Lst2 = _unitOfWork.DataSources.GetAll().ToList();
            var DataSourcesList = Lst2.Select(
                   u => new SelectListItem
                   {
                       Text = u.Name,
                       Value = u.Id.ToString()
                   });
            ViewBag.DataSourcesList = DataSourcesList;
            ////ViewBag.ControlListSer = JsonConvert.SerializeObject(Lst);
            return View(form);
        }
        //GET-Upsert
        public IActionResult Upsert(int? id)
        {

            if (id is null || id == 0)
            {
                //Create Form
                FrmForms form = new();
                return View(form);
            }
            else
            {
                //Update Product
                var form = _unitOfWork.Form.GetFirstOrDefault(u => u.Id == id);

                return View(form);
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(FrmForms obj)
        {
            if (ModelState.IsValid)
            {

                if (obj.Id == 0)
                {
                    _unitOfWork.Form.Add(obj);


                }
                else
                {
                    _unitOfWork.Form.Update(obj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Form created successfully";
                var data = _unitOfWork.Form.GetLastOrDefault();
                return RedirectToAction("FormQuestions", new { id = data.Id });
            }
            return View(obj);
        }
        #region APIs
        [HttpGet]
        public IActionResult GetALl()
        {
            var FormList = _unitOfWork.Form.GetAll();
            return Json(new { data = FormList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.Form.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Form.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Form Deleted Successfully" });

        }
        #endregion
    }
}
