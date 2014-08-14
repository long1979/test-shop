using System.Linq;
using System.Web.Mvc;
using TestShop.DataLayer;
using TestShop.DataLayer.Interfaces;
using TestShop.Dto.TestGoods;
using TestShop.FakeDataLayer;

namespace TestShop.Controllers
{
	public class TestGoodsController : Controller
	{
		private IRepository<TestEntity> _repo;

		public TestGoodsController()
		{
			_repo = RepositoryFactory.Instance.CreateRepository<TestEntity>();
		}

		// GET: TestGoods
		public ActionResult Index()
		{
			return View(_repo.GetAll().ToList());
		}

		public ActionResult Create()
		{
			return View(new CreateDto());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CreateDto model)
		{
			if (!ModelState.IsValid)
				return View(model);

			_repo.Create(new TestEntity
			{
				Name = model.Name
			});

			return RedirectToAction("Index");
		}

		public ActionResult Update(UpdateRequestDto model)
		{
			var entity = _repo.Get(model.EntityId);
			if (entity == null)
				return RedirectToAction("Index");

			return View(entity);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(UpdateResponseDto model)
		{
			var entity = _repo.Get(model.EntityId);
			if (entity == null)
				return RedirectToAction("Index");

			entity.Name = model.Name;

			_repo.Update(entity);

			return RedirectToAction("Index");
		}


		public ActionResult Delete(DeleteRequestDto model)
		{
			var entity = _repo.Get(model.EntityId);
			if (entity == null)
				return RedirectToAction("Index");

			return View(entity);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(DeleteResponseDto model)
		{
			var entity = _repo.Get(model.EntityId);
			if (entity == null)
				return RedirectToAction("Index");

			_repo.Delete(entity);

			return RedirectToAction("Index");
		}
	}
}

